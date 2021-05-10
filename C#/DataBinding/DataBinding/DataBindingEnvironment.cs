using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace UserDataBinding
{
    public class DataBindingEnvironment
    {
        public EventHandler valueChangedEventHandler;
    }

    public static class DataBindingTool
    {
        public static void RegisterDataChangedEvent(BaseDataClass dataSource, Control control)
        {
            TypeDescriptor.GetProperties(dataSource.GetType())[control.Name].AddValueChanged(dataSource, dataSource.Env.valueChangedEventHandler);
        }

        public static void RemoveDataChangedEvent(BaseDataClass dataSource, Control control)
        {
            TypeDescriptor.GetProperties(dataSource.GetType())[control.Name].RemoveValueChanged(dataSource, dataSource.Env.valueChangedEventHandler);
        }

        public static void RegisterDataChangedEvent(BaseDataClass dataSource, params Control[] controls)
        {
            foreach (var control in controls)
            {
                RegisterDataChangedEvent(dataSource, control);
            }
        }

        public static void RemoveDataChangedEvent(BaseDataClass dataSource, params Control[] controls)
        {
            foreach (var control in controls)
            {
                RemoveDataChangedEvent(dataSource, control);
            }
        }
    }

    /// <summary>
    /// 管理所有DataBinding，根據Property的名稱管理各個Form的Control
    /// </summary>
    ///
    public class DataBindingService
    {
        private class UIDataPackage
        {
            public UIDataPackage(string name, object objectValue)
            {
                Name = name;
                Object = objectValue;
            }

            public string Name { get; }
            public object Object { get; }
        }

        private Form TargetForm;
        private Queue<UIDataPackage> _uiDataQueue;
        private Dictionary<string, object> _uiUpdateTempDictionary = new Dictionary<string, object>();

        public DataBindingService(Form targetForm)
        {
            TargetForm = targetForm;
            _uiDataQueue = new Queue<UIDataPackage>();
        }

        public void DataChangedEnqueue(object sender, EventArgs e)
        {
            _uiDataQueue.Enqueue(new UIDataPackage((e as PropertyChangedEventArgs)?.PropertyName, sender));
        }

        public void TimerTickedToUpdateUIControl(object sender, EventArgs e)
        {
            _uiUpdateTempDictionary.Clear();
            while (_uiDataQueue.Count > 0)
            {
                UIDataPackage data = _uiDataQueue.Dequeue();
                if (!_uiUpdateTempDictionary.ContainsKey(data.Name))
                {
                    _uiUpdateTempDictionary.Add(data.Name, data.Object);
                }
                else
                {
                    _uiUpdateTempDictionary[data.Name] = data.Object;
                }
            }
            foreach (var item in _uiUpdateTempDictionary)
            {
                ControlProcess(item.Key, TypeDescriptor.GetProperties(TypeDescriptor.GetReflectionType(item.Value))[item.Key].GetValue(item.Value));
            }
        }

        private void ControlProcess(string propertyName, object sender)
        {
            Control control;
            switch (sender)
            {
                case string value:
                    control = TargetForm.Controls.Find(propertyName, true)[0];
                    DataBindingUpdate.PrintOnForm("Text", control, value);
                    break;

                case decimal value:
                    control = TargetForm.Controls.Find(propertyName, true)[0];
                    DataBindingUpdate.PrintOnForm("Value", control, value);
                    break;

                case bool value:
                    control = TargetForm.Controls.Find(propertyName, true)[0];
                    DataBindingUpdate.PrintOnForm("Checked", control, value);
                    break;
            }
            Console.WriteLine(propertyName + " : " + sender);
        }
    }

    /// <summary>
    /// 利用委派手法，確保在Thread-Safe的前提下定義如何更新GUI上Control的方法
    /// </summary>
    public static class DataBindingUpdate
    {
        private delegate void PrintControlHandler(string propertyName, Control control, object value);

        public static void PrintOnForm(string propertyName, Control calledControl, object value)
        {
            if (calledControl.InvokeRequired)
            {
                PrintControlHandler printHandler = new PrintControlHandler(PrintOnForm);
                try
                {
                    calledControl.Invoke(printHandler, propertyName, calledControl, value);
                }
                catch { }
            }
            else
            {
                try
                {
                    TypeDescriptor.GetProperties(TypeDescriptor.GetReflectionType(calledControl))[propertyName].SetValue(calledControl, value);
                }
                catch { }
            }
        }
    }
}
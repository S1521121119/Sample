using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UserDataBinding
{
    public class BaseDataClass : INotifyPropertyChanged
    {
        public DataBindingEnvironment Env { get; }

        public BaseDataClass(DataBindingEnvironment env, DataBindingService dataBindingBase)
        {
            Env = env;
            env.valueChangedEventHandler += new EventHandler(dataBindingBase.DataChangedEnqueue);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void FireDataChangedEvt(string propertyName)
        {
            FireDataChangedEvt(this, propertyName);
        }

        protected virtual void FireDataChangedEvt(object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetAndFire<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (field == null || EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            FireDataChangedEvt(this, propertyName);
            return true;
        }
    }

    public class UserDataClass : BaseDataClass
    {
        public UserDataClass(DataBindingEnvironment env, DataBindingService dataBindingBase) : base(env, dataBindingBase)
        { }

        private string _name = string.Empty;
        private string _command = string.Empty;
        private decimal _data = 0;
        private bool _bool = false;

        public string TBName
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    SetAndFire(ref _name, value);
                }
            }
        }

        public string TBCommand
        {
            get => _command;
            set
            {
                if (_command != value)
                {
                    SetAndFire(ref _command, value);
                }
            }
        }

        public decimal TBData
        {
            get => _data;
            set
            {
                if (_data != value)
                {
                    SetAndFire(ref _data, value);
                }
            }
        }

        public bool TBStatus
        {
            get => _bool;
            set
            {
                if (_bool != value)
                {
                    SetAndFire(ref _bool, value);
                }
            }
        }
    }

    public class MyDataClass : BaseDataClass
    {
        public MyDataClass(DataBindingEnvironment env, DataBindingService dataBindingBase) : base(env, dataBindingBase)
        { }

        private decimal _data = 0;
        private bool _bool = false;

        public decimal TBData2
        {
            get => _data;
            set
            {
                if (_data != value)
                {
                    SetAndFire(ref _data, value);
                }
            }
        }

        public bool TBStatus2
        {
            get => _bool;
            set
            {
                if (_bool != value)
                {
                    SetAndFire(ref _bool, value);
                }
            }
        }
    }
}
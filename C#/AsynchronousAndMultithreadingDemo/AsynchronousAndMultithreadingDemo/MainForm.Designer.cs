
namespace AsynchronousAndMultithreadingDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCallback = new System.Windows.Forms.Button();
            this.BtnNoParamNoReturn = new System.Windows.Forms.Button();
            this.BtnNoParamHasReturn = new System.Windows.Forms.Button();
            this.BtnHasParamNoReturn = new System.Windows.Forms.Button();
            this.BtnHasParamHasReturn = new System.Windows.Forms.Button();
            this.BtnWaitOne = new System.Windows.Forms.Button();
            this.BtnIsCompleted = new System.Windows.Forms.Button();
            this.BtnHasParamHasReturnThread = new System.Windows.Forms.Button();
            this.BtnHasParamNoReturnThread = new System.Windows.Forms.Button();
            this.BtnNoParamHasReturnThread = new System.Windows.Forms.Button();
            this.BtnNoParamNoReturnThread = new System.Windows.Forms.Button();
            this.BtnCallbackThread = new System.Windows.Forms.Button();
            this.BtnHasParamHasReturnTask = new System.Windows.Forms.Button();
            this.GbxDelegate = new System.Windows.Forms.GroupBox();
            this.GbxThread = new System.Windows.Forms.GroupBox();
            this.GbxTask = new System.Windows.Forms.GroupBox();
            this.BtnContinueWhenAll = new System.Windows.Forms.Button();
            this.BtnContinueWhenAny = new System.Windows.Forms.Button();
            this.BtnWaitAll = new System.Windows.Forms.Button();
            this.BtnWhenAll = new System.Windows.Forms.Button();
            this.BtnWaitAllNoBlock = new System.Windows.Forms.Button();
            this.BtnWhenAny = new System.Windows.Forms.Button();
            this.BtnWaitAnyNoBlock = new System.Windows.Forms.Button();
            this.BtnWaitAny = new System.Windows.Forms.Button();
            this.BtnContinueWith = new System.Windows.Forms.Button();
            this.BtnHasParamHasReturnTaskNoBlock = new System.Windows.Forms.Button();
            this.BtnNoParamNoReturnTask_3 = new System.Windows.Forms.Button();
            this.BtnNoParamNoReturnTask_2 = new System.Windows.Forms.Button();
            this.BtnNoParamNoReturnTask_1 = new System.Windows.Forms.Button();
            this.GbxThreadPool = new System.Windows.Forms.GroupBox();
            this.BtnQueueUserWorkItem = new System.Windows.Forms.Button();
            this.GbxParallel = new System.Windows.Forms.GroupBox();
            this.BtnInvoke = new System.Windows.Forms.Button();
            this.BtnForeach = new System.Windows.Forms.Button();
            this.BtnFor = new System.Windows.Forms.Button();
            this.GbxAsyncAndAwait = new System.Windows.Forms.GroupBox();
            this.BtnAsync = new System.Windows.Forms.Button();
            this.GbxCancleMultiThread = new System.Windows.Forms.GroupBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnManuResetEvent = new System.Windows.Forms.Button();
            this.BtnExternalCancel = new System.Windows.Forms.Button();
            this.BtnInnerCancel1 = new System.Windows.Forms.Button();
            this.GbxDelegate.SuspendLayout();
            this.GbxThread.SuspendLayout();
            this.GbxTask.SuspendLayout();
            this.GbxThreadPool.SuspendLayout();
            this.GbxParallel.SuspendLayout();
            this.GbxAsyncAndAwait.SuspendLayout();
            this.GbxCancleMultiThread.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCallback
            // 
            this.BtnCallback.Location = new System.Drawing.Point(6, 141);
            this.BtnCallback.Name = "BtnCallback";
            this.BtnCallback.Size = new System.Drawing.Size(120, 24);
            this.BtnCallback.TabIndex = 0;
            this.BtnCallback.Text = "Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.btnCallback_Click);
            // 
            // BtnNoParamNoReturn
            // 
            this.BtnNoParamNoReturn.Location = new System.Drawing.Point(6, 21);
            this.BtnNoParamNoReturn.Name = "BtnNoParamNoReturn";
            this.BtnNoParamNoReturn.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamNoReturn.TabIndex = 1;
            this.BtnNoParamNoReturn.Text = "NoParamNoReturn";
            this.BtnNoParamNoReturn.UseVisualStyleBackColor = true;
            this.BtnNoParamNoReturn.Click += new System.EventHandler(this.btnNoParamNoReturn_Click);
            // 
            // BtnNoParamHasReturn
            // 
            this.BtnNoParamHasReturn.Location = new System.Drawing.Point(6, 51);
            this.BtnNoParamHasReturn.Name = "BtnNoParamHasReturn";
            this.BtnNoParamHasReturn.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamHasReturn.TabIndex = 2;
            this.BtnNoParamHasReturn.Text = "NoParamHasReturn";
            this.BtnNoParamHasReturn.UseVisualStyleBackColor = true;
            this.BtnNoParamHasReturn.Click += new System.EventHandler(this.btnNoParamHasReturn_Click);
            // 
            // BtnHasParamNoReturn
            // 
            this.BtnHasParamNoReturn.Location = new System.Drawing.Point(6, 81);
            this.BtnHasParamNoReturn.Name = "BtnHasParamNoReturn";
            this.BtnHasParamNoReturn.Size = new System.Drawing.Size(120, 24);
            this.BtnHasParamNoReturn.TabIndex = 3;
            this.BtnHasParamNoReturn.Text = "HasParamNoReturn";
            this.BtnHasParamNoReturn.UseVisualStyleBackColor = true;
            this.BtnHasParamNoReturn.Click += new System.EventHandler(this.btnHasParamNoReturn_Click);
            // 
            // BtnHasParamHasReturn
            // 
            this.BtnHasParamHasReturn.Location = new System.Drawing.Point(6, 111);
            this.BtnHasParamHasReturn.Name = "BtnHasParamHasReturn";
            this.BtnHasParamHasReturn.Size = new System.Drawing.Size(120, 24);
            this.BtnHasParamHasReturn.TabIndex = 3;
            this.BtnHasParamHasReturn.Text = "HasParamHasReturn";
            this.BtnHasParamHasReturn.UseVisualStyleBackColor = true;
            this.BtnHasParamHasReturn.Click += new System.EventHandler(this.btnHasParamHasReturn_Click);
            // 
            // BtnWaitOne
            // 
            this.BtnWaitOne.Location = new System.Drawing.Point(6, 171);
            this.BtnWaitOne.Name = "BtnWaitOne";
            this.BtnWaitOne.Size = new System.Drawing.Size(120, 24);
            this.BtnWaitOne.TabIndex = 0;
            this.BtnWaitOne.Text = "WaitOne";
            this.BtnWaitOne.UseVisualStyleBackColor = true;
            this.BtnWaitOne.Click += new System.EventHandler(this.btnWaitOne_Click);
            // 
            // BtnIsCompleted
            // 
            this.BtnIsCompleted.Location = new System.Drawing.Point(6, 201);
            this.BtnIsCompleted.Name = "BtnIsCompleted";
            this.BtnIsCompleted.Size = new System.Drawing.Size(120, 24);
            this.BtnIsCompleted.TabIndex = 0;
            this.BtnIsCompleted.Text = "IsCompleted";
            this.BtnIsCompleted.UseVisualStyleBackColor = true;
            this.BtnIsCompleted.Click += new System.EventHandler(this.btnIsCompleted_Click);
            // 
            // BtnHasParamHasReturnThread
            // 
            this.BtnHasParamHasReturnThread.Location = new System.Drawing.Point(6, 111);
            this.BtnHasParamHasReturnThread.Name = "BtnHasParamHasReturnThread";
            this.BtnHasParamHasReturnThread.Size = new System.Drawing.Size(120, 24);
            this.BtnHasParamHasReturnThread.TabIndex = 7;
            this.BtnHasParamHasReturnThread.Text = "HasParamHasReturn";
            this.BtnHasParamHasReturnThread.UseVisualStyleBackColor = true;
            this.BtnHasParamHasReturnThread.Click += new System.EventHandler(this.btnHasParamHasReturnThread_Click);
            // 
            // BtnHasParamNoReturnThread
            // 
            this.BtnHasParamNoReturnThread.Location = new System.Drawing.Point(6, 81);
            this.BtnHasParamNoReturnThread.Name = "BtnHasParamNoReturnThread";
            this.BtnHasParamNoReturnThread.Size = new System.Drawing.Size(120, 24);
            this.BtnHasParamNoReturnThread.TabIndex = 8;
            this.BtnHasParamNoReturnThread.Text = "HasParamNoReturn";
            this.BtnHasParamNoReturnThread.UseVisualStyleBackColor = true;
            this.BtnHasParamNoReturnThread.Click += new System.EventHandler(this.btnHasParamNoReturnThread_Click);
            // 
            // BtnNoParamHasReturnThread
            // 
            this.BtnNoParamHasReturnThread.Location = new System.Drawing.Point(6, 51);
            this.BtnNoParamHasReturnThread.Name = "BtnNoParamHasReturnThread";
            this.BtnNoParamHasReturnThread.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamHasReturnThread.TabIndex = 6;
            this.BtnNoParamHasReturnThread.Text = "NoParamHasReturn";
            this.BtnNoParamHasReturnThread.UseVisualStyleBackColor = true;
            this.BtnNoParamHasReturnThread.Click += new System.EventHandler(this.btnNoParamHasReturnThread_Click);
            // 
            // BtnNoParamNoReturnThread
            // 
            this.BtnNoParamNoReturnThread.Location = new System.Drawing.Point(6, 21);
            this.BtnNoParamNoReturnThread.Name = "BtnNoParamNoReturnThread";
            this.BtnNoParamNoReturnThread.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamNoReturnThread.TabIndex = 5;
            this.BtnNoParamNoReturnThread.Text = "NoParamNoReturn";
            this.BtnNoParamNoReturnThread.UseVisualStyleBackColor = true;
            this.BtnNoParamNoReturnThread.Click += new System.EventHandler(this.btnNoParamNoReturnThread_Click);
            // 
            // BtnCallbackThread
            // 
            this.BtnCallbackThread.Location = new System.Drawing.Point(6, 141);
            this.BtnCallbackThread.Name = "BtnCallbackThread";
            this.BtnCallbackThread.Size = new System.Drawing.Size(120, 24);
            this.BtnCallbackThread.TabIndex = 4;
            this.BtnCallbackThread.Text = "Callback";
            this.BtnCallbackThread.UseVisualStyleBackColor = true;
            this.BtnCallbackThread.Click += new System.EventHandler(this.btnCallbackThread_Click);
            // 
            // BtnHasParamHasReturnTask
            // 
            this.BtnHasParamHasReturnTask.Location = new System.Drawing.Point(6, 111);
            this.BtnHasParamHasReturnTask.Name = "BtnHasParamHasReturnTask";
            this.BtnHasParamHasReturnTask.Size = new System.Drawing.Size(120, 24);
            this.BtnHasParamHasReturnTask.TabIndex = 9;
            this.BtnHasParamHasReturnTask.Text = "HasParamHasReturn";
            this.BtnHasParamHasReturnTask.UseVisualStyleBackColor = true;
            this.BtnHasParamHasReturnTask.Click += new System.EventHandler(this.btnHasParamHasReturnTask_Click);
            // 
            // GbxDelegate
            // 
            this.GbxDelegate.Controls.Add(this.BtnNoParamNoReturn);
            this.GbxDelegate.Controls.Add(this.BtnCallback);
            this.GbxDelegate.Controls.Add(this.BtnWaitOne);
            this.GbxDelegate.Controls.Add(this.BtnIsCompleted);
            this.GbxDelegate.Controls.Add(this.BtnNoParamHasReturn);
            this.GbxDelegate.Controls.Add(this.BtnHasParamNoReturn);
            this.GbxDelegate.Controls.Add(this.BtnHasParamHasReturn);
            this.GbxDelegate.Location = new System.Drawing.Point(12, 12);
            this.GbxDelegate.Name = "GbxDelegate";
            this.GbxDelegate.Size = new System.Drawing.Size(130, 264);
            this.GbxDelegate.TabIndex = 10;
            this.GbxDelegate.TabStop = false;
            this.GbxDelegate.Text = "Delegate";
            // 
            // GbxThread
            // 
            this.GbxThread.Controls.Add(this.BtnNoParamNoReturnThread);
            this.GbxThread.Controls.Add(this.BtnCallbackThread);
            this.GbxThread.Controls.Add(this.BtnNoParamHasReturnThread);
            this.GbxThread.Controls.Add(this.BtnHasParamHasReturnThread);
            this.GbxThread.Controls.Add(this.BtnHasParamNoReturnThread);
            this.GbxThread.Location = new System.Drawing.Point(150, 12);
            this.GbxThread.Name = "GbxThread";
            this.GbxThread.Size = new System.Drawing.Size(130, 264);
            this.GbxThread.TabIndex = 11;
            this.GbxThread.TabStop = false;
            this.GbxThread.Text = "Thread";
            // 
            // GbxTask
            // 
            this.GbxTask.Controls.Add(this.BtnContinueWhenAll);
            this.GbxTask.Controls.Add(this.BtnContinueWhenAny);
            this.GbxTask.Controls.Add(this.BtnWaitAll);
            this.GbxTask.Controls.Add(this.BtnWhenAll);
            this.GbxTask.Controls.Add(this.BtnWaitAllNoBlock);
            this.GbxTask.Controls.Add(this.BtnWhenAny);
            this.GbxTask.Controls.Add(this.BtnWaitAnyNoBlock);
            this.GbxTask.Controls.Add(this.BtnWaitAny);
            this.GbxTask.Controls.Add(this.BtnContinueWith);
            this.GbxTask.Controls.Add(this.BtnHasParamHasReturnTaskNoBlock);
            this.GbxTask.Controls.Add(this.BtnNoParamNoReturnTask_3);
            this.GbxTask.Controls.Add(this.BtnNoParamNoReturnTask_2);
            this.GbxTask.Controls.Add(this.BtnNoParamNoReturnTask_1);
            this.GbxTask.Controls.Add(this.BtnHasParamHasReturnTask);
            this.GbxTask.Location = new System.Drawing.Point(288, 12);
            this.GbxTask.Name = "GbxTask";
            this.GbxTask.Size = new System.Drawing.Size(386, 264);
            this.GbxTask.TabIndex = 12;
            this.GbxTask.TabStop = false;
            this.GbxTask.Text = "Task";
            // 
            // BtnContinueWhenAll
            // 
            this.BtnContinueWhenAll.Location = new System.Drawing.Point(258, 141);
            this.BtnContinueWhenAll.Name = "BtnContinueWhenAll";
            this.BtnContinueWhenAll.Size = new System.Drawing.Size(120, 24);
            this.BtnContinueWhenAll.TabIndex = 13;
            this.BtnContinueWhenAll.Text = "ContinueWhenAll";
            this.BtnContinueWhenAll.UseVisualStyleBackColor = true;
            this.BtnContinueWhenAll.Click += new System.EventHandler(this.btnContinueWhenAll_Click);
            // 
            // BtnContinueWhenAny
            // 
            this.BtnContinueWhenAny.Location = new System.Drawing.Point(132, 141);
            this.BtnContinueWhenAny.Name = "BtnContinueWhenAny";
            this.BtnContinueWhenAny.Size = new System.Drawing.Size(120, 24);
            this.BtnContinueWhenAny.TabIndex = 13;
            this.BtnContinueWhenAny.Text = "ContinueWhenAny";
            this.BtnContinueWhenAny.UseVisualStyleBackColor = true;
            this.BtnContinueWhenAny.Click += new System.EventHandler(this.btnContinueWhenAny_Click);
            // 
            // BtnWaitAll
            // 
            this.BtnWaitAll.Location = new System.Drawing.Point(132, 171);
            this.BtnWaitAll.Name = "BtnWaitAll";
            this.BtnWaitAll.Size = new System.Drawing.Size(120, 24);
            this.BtnWaitAll.TabIndex = 13;
            this.BtnWaitAll.Text = "WaitAll";
            this.BtnWaitAll.UseVisualStyleBackColor = true;
            this.BtnWaitAll.Click += new System.EventHandler(this.btnWaitAll_Click);
            // 
            // BtnWhenAll
            // 
            this.BtnWhenAll.Location = new System.Drawing.Point(132, 231);
            this.BtnWhenAll.Name = "BtnWhenAll";
            this.BtnWhenAll.Size = new System.Drawing.Size(120, 24);
            this.BtnWhenAll.TabIndex = 13;
            this.BtnWhenAll.Text = "WhenAll";
            this.BtnWhenAll.UseVisualStyleBackColor = true;
            this.BtnWhenAll.Click += new System.EventHandler(this.btnWhenAll_Click);
            // 
            // BtnWaitAllNoBlock
            // 
            this.BtnWaitAllNoBlock.Location = new System.Drawing.Point(132, 201);
            this.BtnWaitAllNoBlock.Name = "BtnWaitAllNoBlock";
            this.BtnWaitAllNoBlock.Size = new System.Drawing.Size(120, 24);
            this.BtnWaitAllNoBlock.TabIndex = 13;
            this.BtnWaitAllNoBlock.Text = "WaitAllNoBlock";
            this.BtnWaitAllNoBlock.UseVisualStyleBackColor = true;
            this.BtnWaitAllNoBlock.Click += new System.EventHandler(this.btnWaitAllNoBlock_Click);
            // 
            // BtnWhenAny
            // 
            this.BtnWhenAny.Location = new System.Drawing.Point(6, 231);
            this.BtnWhenAny.Name = "BtnWhenAny";
            this.BtnWhenAny.Size = new System.Drawing.Size(120, 24);
            this.BtnWhenAny.TabIndex = 13;
            this.BtnWhenAny.Text = "WhenAny";
            this.BtnWhenAny.UseVisualStyleBackColor = true;
            this.BtnWhenAny.Click += new System.EventHandler(this.btnWhenAny_Click);
            // 
            // BtnWaitAnyNoBlock
            // 
            this.BtnWaitAnyNoBlock.Location = new System.Drawing.Point(6, 201);
            this.BtnWaitAnyNoBlock.Name = "BtnWaitAnyNoBlock";
            this.BtnWaitAnyNoBlock.Size = new System.Drawing.Size(120, 24);
            this.BtnWaitAnyNoBlock.TabIndex = 13;
            this.BtnWaitAnyNoBlock.Text = "WaitAnyNoBlock";
            this.BtnWaitAnyNoBlock.UseVisualStyleBackColor = true;
            this.BtnWaitAnyNoBlock.Click += new System.EventHandler(this.btnWaitAnyNoBlock_Click);
            // 
            // BtnWaitAny
            // 
            this.BtnWaitAny.Location = new System.Drawing.Point(6, 171);
            this.BtnWaitAny.Name = "BtnWaitAny";
            this.BtnWaitAny.Size = new System.Drawing.Size(120, 24);
            this.BtnWaitAny.TabIndex = 13;
            this.BtnWaitAny.Text = "WaitAny";
            this.BtnWaitAny.UseVisualStyleBackColor = true;
            this.BtnWaitAny.Click += new System.EventHandler(this.btnWaitAny_Click);
            // 
            // BtnContinueWith
            // 
            this.BtnContinueWith.Location = new System.Drawing.Point(6, 141);
            this.BtnContinueWith.Name = "BtnContinueWith";
            this.BtnContinueWith.Size = new System.Drawing.Size(120, 24);
            this.BtnContinueWith.TabIndex = 13;
            this.BtnContinueWith.Text = "ContinueWith";
            this.BtnContinueWith.UseVisualStyleBackColor = true;
            this.BtnContinueWith.Click += new System.EventHandler(this.btnContinueWith_Click);
            // 
            // BtnHasParamHasReturnTaskNoBlock
            // 
            this.BtnHasParamHasReturnTaskNoBlock.Location = new System.Drawing.Point(132, 111);
            this.BtnHasParamHasReturnTaskNoBlock.Name = "BtnHasParamHasReturnTaskNoBlock";
            this.BtnHasParamHasReturnTaskNoBlock.Size = new System.Drawing.Size(120, 24);
            this.BtnHasParamHasReturnTaskNoBlock.TabIndex = 12;
            this.BtnHasParamHasReturnTaskNoBlock.Text = "HasParamHasReturn";
            this.BtnHasParamHasReturnTaskNoBlock.UseVisualStyleBackColor = true;
            this.BtnHasParamHasReturnTaskNoBlock.Click += new System.EventHandler(this.btnHasParamHasReturnTaskNoBlock_Click);
            // 
            // BtnNoParamNoReturnTask_3
            // 
            this.BtnNoParamNoReturnTask_3.Location = new System.Drawing.Point(258, 21);
            this.BtnNoParamNoReturnTask_3.Name = "BtnNoParamNoReturnTask_3";
            this.BtnNoParamNoReturnTask_3.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamNoReturnTask_3.TabIndex = 11;
            this.BtnNoParamNoReturnTask_3.Text = "NoParamNoReturn";
            this.BtnNoParamNoReturnTask_3.UseVisualStyleBackColor = true;
            this.BtnNoParamNoReturnTask_3.Click += new System.EventHandler(this.btnNoParamNoReturnTask_3_Click);
            // 
            // BtnNoParamNoReturnTask_2
            // 
            this.BtnNoParamNoReturnTask_2.Location = new System.Drawing.Point(132, 21);
            this.BtnNoParamNoReturnTask_2.Name = "BtnNoParamNoReturnTask_2";
            this.BtnNoParamNoReturnTask_2.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamNoReturnTask_2.TabIndex = 10;
            this.BtnNoParamNoReturnTask_2.Text = "NoParamNoReturn";
            this.BtnNoParamNoReturnTask_2.UseVisualStyleBackColor = true;
            this.BtnNoParamNoReturnTask_2.Click += new System.EventHandler(this.btnNoParamNoReturnTask_2_Click);
            // 
            // BtnNoParamNoReturnTask_1
            // 
            this.BtnNoParamNoReturnTask_1.Location = new System.Drawing.Point(6, 21);
            this.BtnNoParamNoReturnTask_1.Name = "BtnNoParamNoReturnTask_1";
            this.BtnNoParamNoReturnTask_1.Size = new System.Drawing.Size(120, 24);
            this.BtnNoParamNoReturnTask_1.TabIndex = 9;
            this.BtnNoParamNoReturnTask_1.Text = "NoParamNoReturn";
            this.BtnNoParamNoReturnTask_1.UseVisualStyleBackColor = true;
            this.BtnNoParamNoReturnTask_1.Click += new System.EventHandler(this.btnNoParamNoReturnTask_1_Click);
            // 
            // GbxThreadPool
            // 
            this.GbxThreadPool.Controls.Add(this.BtnQueueUserWorkItem);
            this.GbxThreadPool.Location = new System.Drawing.Point(12, 282);
            this.GbxThreadPool.Name = "GbxThreadPool";
            this.GbxThreadPool.Size = new System.Drawing.Size(130, 170);
            this.GbxThreadPool.TabIndex = 13;
            this.GbxThreadPool.TabStop = false;
            this.GbxThreadPool.Text = "ThreadPool";
            // 
            // BtnQueueUserWorkItem
            // 
            this.BtnQueueUserWorkItem.Location = new System.Drawing.Point(6, 21);
            this.BtnQueueUserWorkItem.Name = "BtnQueueUserWorkItem";
            this.BtnQueueUserWorkItem.Size = new System.Drawing.Size(120, 24);
            this.BtnQueueUserWorkItem.TabIndex = 4;
            this.BtnQueueUserWorkItem.Text = "QueueUserWorkItem";
            this.BtnQueueUserWorkItem.UseVisualStyleBackColor = true;
            this.BtnQueueUserWorkItem.Click += new System.EventHandler(this.BtnQueueUserWorkItem_Click);
            // 
            // GbxParallel
            // 
            this.GbxParallel.Controls.Add(this.BtnInvoke);
            this.GbxParallel.Controls.Add(this.BtnForeach);
            this.GbxParallel.Controls.Add(this.BtnFor);
            this.GbxParallel.Location = new System.Drawing.Point(150, 282);
            this.GbxParallel.Name = "GbxParallel";
            this.GbxParallel.Size = new System.Drawing.Size(130, 170);
            this.GbxParallel.TabIndex = 14;
            this.GbxParallel.TabStop = false;
            this.GbxParallel.Text = "Parallel";
            // 
            // BtnInvoke
            // 
            this.BtnInvoke.Location = new System.Drawing.Point(6, 81);
            this.BtnInvoke.Name = "BtnInvoke";
            this.BtnInvoke.Size = new System.Drawing.Size(120, 24);
            this.BtnInvoke.TabIndex = 6;
            this.BtnInvoke.Text = "Invoke";
            this.BtnInvoke.UseVisualStyleBackColor = true;
            this.BtnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // BtnForeach
            // 
            this.BtnForeach.Location = new System.Drawing.Point(6, 51);
            this.BtnForeach.Name = "BtnForeach";
            this.BtnForeach.Size = new System.Drawing.Size(120, 24);
            this.BtnForeach.TabIndex = 5;
            this.BtnForeach.Text = "Foreach";
            this.BtnForeach.UseVisualStyleBackColor = true;
            this.BtnForeach.Click += new System.EventHandler(this.btnForeach_Click);
            // 
            // BtnFor
            // 
            this.BtnFor.Location = new System.Drawing.Point(6, 21);
            this.BtnFor.Name = "BtnFor";
            this.BtnFor.Size = new System.Drawing.Size(120, 24);
            this.BtnFor.TabIndex = 4;
            this.BtnFor.Text = "For";
            this.BtnFor.UseVisualStyleBackColor = true;
            this.BtnFor.Click += new System.EventHandler(this.btnFor_Click);
            // 
            // GbxAsyncAndAwait
            // 
            this.GbxAsyncAndAwait.Controls.Add(this.BtnAsync);
            this.GbxAsyncAndAwait.Location = new System.Drawing.Point(288, 282);
            this.GbxAsyncAndAwait.Name = "GbxAsyncAndAwait";
            this.GbxAsyncAndAwait.Size = new System.Drawing.Size(130, 170);
            this.GbxAsyncAndAwait.TabIndex = 7;
            this.GbxAsyncAndAwait.TabStop = false;
            this.GbxAsyncAndAwait.Text = "AsyncAndAwait";
            // 
            // BtnAsync
            // 
            this.BtnAsync.Location = new System.Drawing.Point(6, 21);
            this.BtnAsync.Name = "BtnAsync";
            this.BtnAsync.Size = new System.Drawing.Size(120, 24);
            this.BtnAsync.TabIndex = 14;
            this.BtnAsync.Text = "Async";
            this.BtnAsync.UseVisualStyleBackColor = true;
            this.BtnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // GbxCancleMultiThread
            // 
            this.GbxCancleMultiThread.Controls.Add(this.BtnStop);
            this.GbxCancleMultiThread.Controls.Add(this.BtnStart);
            this.GbxCancleMultiThread.Controls.Add(this.BtnManuResetEvent);
            this.GbxCancleMultiThread.Controls.Add(this.BtnExternalCancel);
            this.GbxCancleMultiThread.Controls.Add(this.BtnInnerCancel1);
            this.GbxCancleMultiThread.Location = new System.Drawing.Point(426, 282);
            this.GbxCancleMultiThread.Name = "GbxCancleMultiThread";
            this.GbxCancleMultiThread.Size = new System.Drawing.Size(130, 170);
            this.GbxCancleMultiThread.TabIndex = 15;
            this.GbxCancleMultiThread.TabStop = false;
            this.GbxCancleMultiThread.Text = "CancleMultiThread";
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(6, 138);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(120, 23);
            this.BtnStop.TabIndex = 19;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(6, 109);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(120, 23);
            this.BtnStart.TabIndex = 18;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // BtnManuResetEvent
            // 
            this.BtnManuResetEvent.Location = new System.Drawing.Point(6, 80);
            this.BtnManuResetEvent.Name = "BtnManuResetEvent";
            this.BtnManuResetEvent.Size = new System.Drawing.Size(120, 23);
            this.BtnManuResetEvent.TabIndex = 17;
            this.BtnManuResetEvent.Text = "ManuResetEvent";
            this.BtnManuResetEvent.UseVisualStyleBackColor = true;
            this.BtnManuResetEvent.Click += new System.EventHandler(this.btnManuResetEvent_Click);
            // 
            // BtnExternalCancel
            // 
            this.BtnExternalCancel.Location = new System.Drawing.Point(6, 50);
            this.BtnExternalCancel.Name = "BtnExternalCancel";
            this.BtnExternalCancel.Size = new System.Drawing.Size(120, 23);
            this.BtnExternalCancel.TabIndex = 16;
            this.BtnExternalCancel.Text = "ExternalCancel";
            this.BtnExternalCancel.UseVisualStyleBackColor = true;
            this.BtnExternalCancel.Click += new System.EventHandler(this.btnExternalCancel_Click);
            // 
            // BtnInnerCancel1
            // 
            this.BtnInnerCancel1.Location = new System.Drawing.Point(6, 21);
            this.BtnInnerCancel1.Name = "BtnInnerCancel1";
            this.BtnInnerCancel1.Size = new System.Drawing.Size(120, 23);
            this.BtnInnerCancel1.TabIndex = 15;
            this.BtnInnerCancel1.Text = "InnerCancel";
            this.BtnInnerCancel1.UseVisualStyleBackColor = true;
            this.BtnInnerCancel1.Click += new System.EventHandler(this.btnInnerCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 460);
            this.Controls.Add(this.GbxCancleMultiThread);
            this.Controls.Add(this.GbxAsyncAndAwait);
            this.Controls.Add(this.GbxParallel);
            this.Controls.Add(this.GbxThreadPool);
            this.Controls.Add(this.GbxTask);
            this.Controls.Add(this.GbxThread);
            this.Controls.Add(this.GbxDelegate);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.GbxDelegate.ResumeLayout(false);
            this.GbxThread.ResumeLayout(false);
            this.GbxTask.ResumeLayout(false);
            this.GbxThreadPool.ResumeLayout(false);
            this.GbxParallel.ResumeLayout(false);
            this.GbxAsyncAndAwait.ResumeLayout(false);
            this.GbxCancleMultiThread.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Button BtnNoParamNoReturn;
        private System.Windows.Forms.Button BtnNoParamHasReturn;
        private System.Windows.Forms.Button BtnHasParamNoReturn;
        private System.Windows.Forms.Button BtnHasParamHasReturn;
        private System.Windows.Forms.Button BtnWaitOne;
        private System.Windows.Forms.Button BtnIsCompleted;
        private System.Windows.Forms.Button BtnHasParamHasReturnThread;
        private System.Windows.Forms.Button BtnHasParamNoReturnThread;
        private System.Windows.Forms.Button BtnNoParamHasReturnThread;
        private System.Windows.Forms.Button BtnNoParamNoReturnThread;
        private System.Windows.Forms.Button BtnCallbackThread;
        private System.Windows.Forms.Button BtnHasParamHasReturnTask;
        private System.Windows.Forms.GroupBox GbxDelegate;
        private System.Windows.Forms.GroupBox GbxThread;
        private System.Windows.Forms.GroupBox GbxTask;
        private System.Windows.Forms.Button BtnNoParamNoReturnTask_1;
        private System.Windows.Forms.Button BtnNoParamNoReturnTask_3;
        private System.Windows.Forms.Button BtnNoParamNoReturnTask_2;
        private System.Windows.Forms.Button BtnHasParamHasReturnTaskNoBlock;
        private System.Windows.Forms.Button BtnContinueWith;
        private System.Windows.Forms.Button BtnContinueWhenAny;
        private System.Windows.Forms.Button BtnContinueWhenAll;
        private System.Windows.Forms.Button BtnWaitAny;
        private System.Windows.Forms.Button BtnWaitAll;
        private System.Windows.Forms.Button BtnWaitAnyNoBlock;
        private System.Windows.Forms.Button BtnWaitAllNoBlock;
        private System.Windows.Forms.Button BtnWhenAll;
        private System.Windows.Forms.Button BtnWhenAny;
        private System.Windows.Forms.GroupBox GbxThreadPool;
        private System.Windows.Forms.Button BtnQueueUserWorkItem;
        private System.Windows.Forms.GroupBox GbxParallel;
        private System.Windows.Forms.Button BtnInvoke;
        private System.Windows.Forms.Button BtnForeach;
        private System.Windows.Forms.Button BtnFor;
        private System.Windows.Forms.GroupBox GbxAsyncAndAwait;
        private System.Windows.Forms.Button BtnAsync;
        private System.Windows.Forms.GroupBox GbxCancleMultiThread;
        private System.Windows.Forms.Button BtnInnerCancel1;
        private System.Windows.Forms.Button BtnExternalCancel;
        private System.Windows.Forms.Button BtnManuResetEvent;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnStart;
    }
}


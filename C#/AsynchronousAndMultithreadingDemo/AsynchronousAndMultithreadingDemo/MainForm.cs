using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousAndMultithreadingDemo
{
    public partial class MainForm : Form
    {
        private int a;

        public MainForm()
        {
            InitializeComponent();
            Task task1 = Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    a++;
                    //Console.WriteLine($"a{i}:{ a++}");
                }
            });
            Task task2 = Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    a--;
                    //Console.WriteLine($"b{i}:{ a--}");
                }
            });
            Task.WaitAll(task1, task2);
            Console.WriteLine(a);
        }

        #region 說明

        /*
        同步與非同步多執行緒的區別：
            1、同步方法卡介面（UI執行緒忙於計算）；非同步多執行緒不卡介面（主執行緒閒置，子執行緒在計算）
            2、同步方法慢（CPU利用率低、資源耗費少）；非同步多執行緒快（CPU利用率高、資源耗費多）
            3、同步方法是有序的；非同步方法是無序的（啟動無序、執行時間不確定、結束無序

        實現非同步多執行緒的6種方式與取消多執行緒：
            1、委託的非同步呼叫
            2、Thread實現多執行緒
            3、Task實現多執行緒
            4、ThreadPool實現多執行緒
            5、Parallel實現多執行緒
            6、async和await實現多執行緒
            7、取消多執行緒

        一、公共類庫

        二、delegate實現多執行緒
            01、無參無返回值
            02、無參有返回值
            03、有參無返回值
            04、有參有返回值
            05、非同步回撥
            06、WaitOne()操作
            07、IsCompleted判斷

        三、Thread實現多執行緒
            01、無參無返回值
            02、無參有返回值
            03、有參無返回值
            04、有參有返回值
            05、非同步回撥

        四、Task實現多執行緒
            01、Start啟動
            02、StartNew啟動
            03、Run啟動
            04、ContinueWith控制任務順序
            05、ContinueWhenAny操作
            06、ContinueWhenAll操作
            07、WaitAny操作
            08、WaitAll操作
            09、WaitAny自定義非阻塞操作
            10、WaitAll自定義非阻塞操作
            11、WhenAny操作
            12、WhenAll操作
            13、有引數有返回值
            14、有引數有返回值 不阻塞

        五、ThreadPool實現多執行緒
            1、QueueUserWorkItem的用法

        六、Parallel實現多執行緒
            01、For的用法
            02、Foreach的用法
            03、Invoke操作

        七、async+await實現多執行緒

        八、取消多執行緒的執行
            01、CancellationTokenSource的用法1
            02、CancellationTokenSource的用法2
            03、ManualResetEvent的用法
        */

        #endregion 說明

        #region 一、公共類庫

        public delegate void DoSomething();

        public delegate int DoSomethingReturn();

        public delegate void DoMore(int age, string name);

        public delegate int DoMoreReturn(int age, string name);

        public class CommonDelegate
        {
            public static void DoSomethingMethod()
            {
                Console.WriteLine("Sub-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("Sub-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            }

            public static int DoSomethingReturnMethod()
            {
                Console.WriteLine("Sub-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("Sub-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                return 99;
            }

            public static void DoMoreMethod(int age, string name)
            {
                Console.WriteLine("Sub-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Console.WriteLine("age={0},name={1}", age, name);
                Thread.Sleep(3000);
                Console.WriteLine("Sub-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            }

            public static int DoMoreReturnMethod(int age, string name)
            {
                Console.WriteLine("Sub-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Console.WriteLine("age={0},name={1}", age, name);
                Thread.Sleep(3000);
                Console.WriteLine("Sub-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                return 99;
            }
        }

        #endregion 一、公共類庫

        #region 二、delegate實現多執行緒

        //01、無參無返回值
        private void btnNoParamNoReturn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoSomething doSomething = new DoSomething(CommonDelegate.DoSomethingMethod);
            doSomething.BeginInvoke(null, null);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //02、無參有返回值
        private void btnNoParamHasReturn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoSomethingReturn doSomething = new DoSomethingReturn(CommonDelegate.DoSomethingReturnMethod);
            IAsyncResult iasyncResult = doSomething.BeginInvoke(null, null);
            int result = doSomething.EndInvoke(iasyncResult);
            Console.WriteLine("result={0}", result);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //03、有參無返回值
        private void btnHasParamNoReturn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoMore doMore = new DoMore(CommonDelegate.DoMoreMethod);
            doMore.BeginInvoke(16, "guo", null, null);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //04、有參有返回值
        private void btnHasParamHasReturn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoMoreReturn doMoreReturn = new DoMoreReturn(CommonDelegate.DoMoreReturnMethod);
            IAsyncResult iasyncResult = doMoreReturn.BeginInvoke(16, "guo", null, null);
            int result = doMoreReturn.EndInvoke(iasyncResult);
            Console.WriteLine("result={0}", result);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //05、非同步回撥
        //Can't not use in C# 5.0
        private void btnCallback_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoMoreReturn doMore = new DoMoreReturn(CommonDelegate.DoMoreReturnMethod);
            doMore.BeginInvoke(16, "guo", Callback, "wulala");
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        private void Callback(IAsyncResult iasyncResult)
        {
            Console.WriteLine("Callback-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            AsyncResult asyncResult = (AsyncResult)iasyncResult;
            //獲取回撥方法的引數
            string parameter = asyncResult.AsyncState.ToString();
            //獲取委託的返回值
            DoMoreReturn doMore = (DoMoreReturn)asyncResult.AsyncDelegate;
            int result = doMore.EndInvoke(asyncResult);
            Thread.Sleep(3000);
            Console.WriteLine("result={0},parameter={1}", result, parameter);
            Console.WriteLine("Callback-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //06、WaitOne()操作
        private void btnWaitOne_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoMore doMore = new DoMore(CommonDelegate.DoMoreMethod);
            IAsyncResult iasyncResult = doMore.BeginInvoke(16, "guo", null, null);
            //無參或引數為-1表示無限等等
            //iasyncResult.AsyncWaitHandle.WaitOne();
            //iasyncResult.AsyncWaitHandle.WaitOne(-1);
            //表示等待1000ms
            iasyncResult.AsyncWaitHandle.WaitOne(1000);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //07、IsCompleted判斷
        private void btnIsCompleted_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            DoMoreReturn doMoreReturn = new DoMoreReturn(CommonDelegate.DoMoreReturnMethod);
            IAsyncResult iasyncResult = doMoreReturn.BeginInvoke(16, "guo", null, null);
            while (!iasyncResult.IsCompleted)
            {
                Console.WriteLine("正在執行......");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        #endregion 二、delegate實現多執行緒

        #region 三、Thread實現多執行緒

        //01、無參無返回值
        private void btnNoParamNoReturnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            ThreadStart threadStart = new ThreadStart(CommonDelegate.DoSomethingMethod);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //02、無參有返回值
        private void btnNoParamHasReturnThread_Click(object sender, EventArgs e)
        {
            //Thread預設不支援返回值
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Func<int> func = new Func<int>(CommonDelegate.DoSomethingReturnMethod);
            Func<int> beginInvokeFunc = BeginInvoke<int>(func);
            Console.WriteLine("Main-Other-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Thread.Sleep(2000);
            Console.WriteLine("Main-Other-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //想獲取計算結果必須等待
            int result = beginInvokeFunc.Invoke();
            Console.WriteLine("result=" + result);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        /// <summary>
        /// 基於Thread封裝一個支援返回值的方法
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="callback"></param>
        private Func<T> BeginInvoke<T>(Func<T> func)
        {
            T t = default(T);
            ThreadStart start = new ThreadStart(() =>
            {
                //func.Invoke()等價於func()表示同步執行
                t = func.Invoke();
            });
            Thread thread = new Thread(start);
            thread.Start();
            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }

        //03、有參無返回值
        private void btnHasParamNoReturnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //委託方法不能省略引數型別，lambda表示式可省略引數型別
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(delegate (object name)
            {
                Console.WriteLine("Sub-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("name={0}", name);
                Console.WriteLine("Sub-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Thread thread = new Thread(threadStart);
            //只能有一個object型別的引數
            thread.Start("guo");
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //04、有參有返回值
        private void btnHasParamHasReturnThread_Click(object sender, EventArgs e)
        {
            //Thread預設不支援返回值
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Func<int, string, int> func = new Func<int, string, int>(CommonDelegate.DoMoreReturnMethod);
            Func<int> beginInvokeFunc = BeginInvoke<int>(func, 16, "guo");
            Console.WriteLine("Main-Other-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Thread.Sleep(2000);
            Console.WriteLine("Main-Other-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            //想獲取計算結果必須等待
            int result = beginInvokeFunc.Invoke();
            Console.WriteLine("result=" + result);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        /// <summary>
        /// 基於Thread封裝一個支援返回值的方法
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="callback"></param>
        private Func<T> BeginInvoke<T>(Func<int, string, T> func, int age, string name)
        {
            T t = default(T);
            ThreadStart start = new ThreadStart(() =>
            {
                //func.Invoke()等價於func()表示同步執行
                t = func.Invoke(age, name);
            });
            Thread thread = new Thread(start);
            thread.Start();
            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }

        //05、非同步回撥
        private void btnCallbackThread_Click(object sender, EventArgs e)
        {
            //Thread預設不支援回撥
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            ThreadStart threadStart = new ThreadStart(CommonDelegate.DoSomethingMethod);
            Action callback = new Action(() =>
            {
                Console.WriteLine("Callback-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("Callback-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            BeginInvoke(threadStart, callback);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        /// <summary>
        /// 基於Thread封裝一個支援回撥的方法
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="callback"></param>
        private void BeginInvoke(ThreadStart threadStart, Action callback)
        {
            ThreadStart start = new ThreadStart(() =>
            {
                //threadStart.Invoke()等價於threadStart()表示同步執行
                threadStart.Invoke();
                callback.Invoke();
            });
            Thread thread = new Thread(start);
            thread.Start();
        }

        #endregion 三、Thread實現多執行緒

        #region 四、Task實現多執行緒

        //01、Start啟動
        private void btnNoParamNoReturnTask_1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task task = new Task(CommonDelegate.DoSomethingMethod);
            task.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //02、StartNew啟動
        private void btnNoParamNoReturnTask_2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task task = new TaskFactory().StartNew(CommonDelegate.DoSomethingMethod);
            Thread.Sleep(1000);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //03、Run啟動
        private void btnNoParamNoReturnTask_3_Click(object sender, EventArgs e)
        {
            //Task.Run 是根據 Task.Factory.StartNew 相同邏輯實現，將 Action 帶入其他參數帶入預設值
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task task = Task.Run(new Action(CommonDelegate.DoSomethingMethod));
            Thread.Sleep(1000);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //04、ContinueWith控制任務順序
        private void btnContinueWith_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task task = new Task(CommonDelegate.DoSomethingMethod);
            //利用ContinueWith()為任務排序不會阻塞主執行緒
            task.ContinueWith((a) =>
            {
                Console.WriteLine("ContinueWith-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("ContinueWith-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            task.Start();
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //05、ContinueWhenAny操作
        private void btnContinueWhenAny_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task3 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            taskFactory.ContinueWhenAny(new Task[] { task1, task2, task3 }, (a) =>
            {
                Console.WriteLine("ContinueWhenAny-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("ContinueWhenAny-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //06、ContinueWhenAll操作
        private void btnContinueWhenAll_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task3 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            taskFactory.ContinueWhenAll(new Task[] { task1, task2, task3 }, (a) =>
            {
                Console.WriteLine("ContinueWhenAll-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(1000);
                Console.WriteLine("ContinueWhenAll-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //07、WaitAny操作
        private void btnWaitAny_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(4000);
                Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task3 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task.WaitAny(new Task[] { task1, task2, task3 });
            Console.WriteLine("WaitAny執行之後【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //08、WaitAll操作
        private void btnWaitAll_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(4000);
                Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task3 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task.WaitAll(new Task[] { task1, task2, task3 });
            Console.WriteLine("WaitAll執行之後【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //09、WaitAny自定義非阻塞操作
        private void btnWaitAnyNoBlock_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(() =>
            {
                Task task1 = taskFactory.StartNew(() =>
                {
                    Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(3000);
                    Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                });
                Task task2 = taskFactory.StartNew(() =>
                {
                    Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(4000);
                    Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                });
                Task task3 = taskFactory.StartNew(() =>
                {
                    Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(5000);
                    Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                });
                Task.WaitAny(new Task[] { task1, task2, task3 });
                Console.WriteLine("WaitAny執行之後【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //10、WaitAll自定義非阻塞操作
        private void btnWaitAllNoBlock_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(() =>
            {
                Task task1 = taskFactory.StartNew(() =>
                {
                    Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(3000);
                    Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                });
                Task task2 = taskFactory.StartNew(() =>
                {
                    Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(4000);
                    Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                });
                Task task3 = taskFactory.StartNew(() =>
                {
                    Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(5000);
                    Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                });
                Task.WaitAll(new Task[] { task1, task2, task3 });
                Console.WriteLine("WaitAll執行之後【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //11、WhenAny操作
        private void btnWhenAny_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(4000);
                Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task3 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task = Task.WhenAny(new Task[] { task1, task2, task3 });
            task.ContinueWith((a) =>
            {
                Console.WriteLine("ContinueWith-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("ContinueWith-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //12、WhenAll操作
        private void btnWhenAll_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            TaskFactory taskFactory = new TaskFactory();
            Task task1 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("任務1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task2 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(4000);
                Console.WriteLine("任務2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task3 = taskFactory.StartNew(() =>
            {
                Console.WriteLine("任務3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(5000);
                Console.WriteLine("任務3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Task task = Task.WhenAll(new Task[] { task1, task2, task3 });
            task.ContinueWith((a) =>
            {
                Console.WriteLine("ContinueWith-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("ContinueWith-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //13、有引數有返回值
        private void btnHasParamHasReturnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task<int> task1 = new Task<int>(new Func<object, int>((a) =>
            {
                Console.WriteLine("a={0}", a);
                Thread.Sleep(2000);
                return 66;
            }), "wulaaa");
            task1.Start();
            Task<int> task2 = new Task<int>(new Func<object, int>((b) =>
            {
                Console.WriteLine("b={0}", b);
                Thread.Sleep(3000);
                return 99;
            }), "wulbbb");
            task2.Start();
            int result1 = task1.Result;
            int result2 = task2.Result;
            Console.WriteLine("result1={0},result2={1}", result1, result2);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //14、有引數有返回值 不阻塞
        private void btnHasParamHasReturnTaskNoBlock_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task.Run(() =>
            {
                Task<int> task1 = new Task<int>(new Func<object, int>((a) =>
                {
                    Console.WriteLine("a={0}", a);
                    Thread.Sleep(2000);
                    return 66;
                }), "wulaaa");
                task1.Start();
                Task<int> task2 = new Task<int>(new Func<object, int>((b) =>
                {
                    Console.WriteLine("b={0}", b);
                    Thread.Sleep(3000);
                    return 99;
                }), "wulbbb");
                task2.Start();
                int result1 = task1.Result;
                int result2 = task2.Result;
                Console.WriteLine("result1={0},result2={1}", result1, result2);
            });
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        #endregion 四、Task實現多執行緒

        #region 五、ThreadPool實現多執行緒

        //1、QueueUserWorkItem的用法
        private void BtnQueueUserWorkItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            ThreadPool.SetMinThreads(2, 1);
            ThreadPool.SetMaxThreads(4, 2);
            ThreadPool.QueueUserWorkItem(new WaitCallback((a) =>
            {
                Console.WriteLine("WorkItem1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(2000);
                Console.WriteLine("WorkItem1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            }));
            ThreadPool.QueueUserWorkItem(new WaitCallback((a) =>
            {
                Console.WriteLine("WorkItem2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("a={0}", a);
                Console.WriteLine("WorkItem2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            }), "wulaaa");
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        #endregion 五、ThreadPool實現多執行緒

        #region 六、Parallel實現多執行緒

        //01、For的用法
        private void btnFor_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Console.WriteLine("--------------------");
            ParallelOptions options = new ParallelOptions();
            //設定最大並行度
            options.MaxDegreeOfParallelism = 3;
            Parallel.For(1, 6, options, (a, loopState) =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("a={0},{1}", a, DateTime.Now);
            });
            Console.WriteLine("--------------------");
            Parallel.For(1, 6, options, (b, loopState) =>
            {
                Console.WriteLine("b={0}-Start：{1}", b, DateTime.Now);
                //立即停止執行當前迴圈之外的其他迴圈
                if (b == 1) loopState.Break();
                Thread.Sleep(3000);
                Console.WriteLine("b={0}-End：{1}", b, DateTime.Now);
            });
            Console.WriteLine("--------------------");
            Parallel.For(1, 6, options, (c, loopState) =>
            {
                Console.WriteLine("c={0}-Start：{1}", c, DateTime.Now);
                //立即停止執行當前迴圈及其他未執行的迴圈
                if (c == 3) loopState.Stop();
                if (loopState.IsStopped) return;
                Thread.Sleep(3000);
                Console.WriteLine("c={0}-End：{1}", c, DateTime.Now);
            });
            Console.WriteLine("--------------------");
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //02、Foreach的用法
        private void btnForeach_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Console.WriteLine("--------------------");
            ParallelOptions options = new ParallelOptions();
            //設定最大並行度
            options.MaxDegreeOfParallelism = 3;
            Parallel.ForEach<int>(new int[] { 1, 2, 3, 4, 5 }, options, (a, loopState) =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("a={0},{1}", a, DateTime.Now);
            });
            Console.WriteLine("--------------------");
            Parallel.ForEach<int>(new int[] { 1, 2, 3, 4, 5 }, options, (b, loopState) =>
            {
                Console.WriteLine("b={0}-Start：{1}", b, DateTime.Now);
                //立即停止執行當前迴圈之外的其他迴圈
                if (b == 1) loopState.Break();
                Thread.Sleep(3000);
                Console.WriteLine("b={0}-End：{1}", b, DateTime.Now);
            });
            Console.WriteLine("--------------------");
            Parallel.ForEach<int>(new int[] { 1, 2, 3, 4, 5 }, options, (c, loopState) =>
            {
                Console.WriteLine("c={0}-Start：{1}", c, DateTime.Now);
                //立即停止執行當前迴圈及其他未執行的迴圈
                if (c == 3) loopState.Stop();
                if (loopState.IsStopped) return;
                Thread.Sleep(3000);
                Console.WriteLine("c={0}-End：{1}", c, DateTime.Now);
            });
            Console.WriteLine("--------------------");
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //03、Invoke操作
        private void btnInvoke_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 3;
            Parallel.Invoke(options,
                () =>
                {
                    Console.WriteLine("Sub1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(1000);
                    Console.WriteLine("Sub1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                },
                () =>
                {
                    Console.WriteLine("Sub2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(3000);
                    Console.WriteLine("Sub2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                },
                () =>
                {
                    Console.WriteLine("Sub3-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(5000);
                    Console.WriteLine("Sub3-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                },
                () =>
                {
                    Console.WriteLine("Sub4-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(1000);
                    Console.WriteLine("Sub4-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                },
                () =>
                {
                    Console.WriteLine("Sub5-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                    Thread.Sleep(1000);
                    Console.WriteLine("Sub5-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                }
            );
            Console.WriteLine("--------------------");
            Parallel.Invoke(options,
               () =>
               {
                   Console.WriteLine("Sub1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                   Thread.Sleep(1000);
                   Console.WriteLine("Sub1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
               },
               () =>
               {
                   Console.WriteLine("Sub2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                   Thread.Sleep(3000);
                   Console.WriteLine("Sub2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
               }
            );
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        #endregion 六、Parallel實現多執行緒

        #region 七、async+await實現多執行緒

        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Async();
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        private async void Async()
        {
            Console.WriteLine("Async-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine("task1-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("task1-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            Console.WriteLine("await task1之前【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            await task1;
            Console.WriteLine("await task1之後【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            Task task2 = Task.Run(() =>
            {
                Console.WriteLine("task2-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
                Thread.Sleep(3000);
                Console.WriteLine("task2-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            });
            await task2;
            Console.WriteLine("Async-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        #endregion 七、async+await實現多執行緒

        #region 八、取消多執行緒的執行

        /// <summary>
        /// Task+CancellationTokenSource共有三種寫法：
        ///
        ///CancellationTokenSource cts = new CancellationTokenSource();
        /// taskFactory.StartNew(() => { }, cts.Token);
        ///Task task3 = new Task(() => { }, cts.Token);
        ///Task.Run(() => { }, cts.Token);
        ///
        /// </summary>

        //01、CancellationTokenSource的用法1
        private void btnInnerCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            CancellationTokenSource cts = new CancellationTokenSource();
            Task task1 = new Task(() =>
            {
                Thread.Sleep(2000);
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("task1：cts已經被取消了");
                }
                else
                {
                    cts.Cancel();
                    Console.WriteLine("task1：取消cts");
                }
            }, cts.Token);
            Task task2 = new Task(() =>
            {
                Thread.Sleep(3000);
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("task2：cts已經被取消了");
                }
                else
                {
                    cts.Cancel();
                    Console.WriteLine("task2：取消cts");
                }
            }, cts.Token);
            task1.Start();
            task2.Start();
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //02、CancellationTokenSource的用法2
        private void btnExternalCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main-Start【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
            CancellationTokenSource cts = new CancellationTokenSource();
            TaskFactory taskFactory = new TaskFactory();
            cts.Cancel();
            Task task1 = taskFactory.StartNew(() =>
            {
                Thread.Sleep(2000);
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("task1：cts已經被取消了");
                }
                else
                {
                    cts.Cancel();
                    Console.WriteLine("task1：取消cts");
                }
            }, cts.Token);
            Task task2 = taskFactory.StartNew(() =>
            {
                Thread.Sleep(3000);
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("task2：cts已經被取消了");
                }
                else
                {
                    cts.Cancel();
                    Console.WriteLine("task2：取消cts");
                }
            }, cts.Token);
            Console.WriteLine("Main-End【ThreadId=" + Thread.CurrentThread.ManagedThreadId + "】：" + DateTime.Now);
        }

        //03、ManualResetEvent的用法
        //引數值為false執行緒預設會阻塞
        private ManualResetEvent mre = new ManualResetEvent(false);

        private void btnManuResetEvent_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            while (true)
            {
                this.mre.WaitOne();
                Thread.Sleep(1000);
                Console.WriteLine("ThreadId=" + Thread.CurrentThread.ManagedThreadId + "：" + DateTime.Now);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //放開執行緒
            this.mre.Set();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //阻塞執行緒
            this.mre.Reset();
        }

        #endregion 八、取消多執行緒的執行
    }
}
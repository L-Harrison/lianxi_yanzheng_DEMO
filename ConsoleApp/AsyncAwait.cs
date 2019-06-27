using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Drawing;

namespace ConsoleApp
{
    /// <summary>
    /// 异步编程  async await
    /// </summary>
    public class AsyncAwait
    {
        public void DoSomethings()
        {
            //Task<int> res = Sum(4, 2);
            //Task<int> r = Sum(0, 0);
            //Console.WriteLine(res.Result);
            //Console.WriteLine(r.Result);
            while (true)
            {
                Console.ReadLine();

                Func<int, Task<int>> function = async x =>
                {
                    Console.WriteLine(x);
                    await Task.Delay(x * 1000);
                    Console.WriteLine($"{x}-qweqwe");
                    return x * 2;
                };
                Stopwatch st = new Stopwatch();
                st.Start();
                Task<int> first = function(2);
                Task<int> second = function(5);
                #region WhenAll
                //var p = Task.WhenAll(first, second);
                //foreach (var item in p.Result)
                //{
                //    Console.WriteLine(item);
                //} 
                #endregion     
                Console.WriteLine(first.Result);
                Console.WriteLine(second.Result);
                st.Stop();
                Console.WriteLine(st.ElapsedMilliseconds);
                Console.ReadLine();
            }
        }
        async Task<int> Sum(int a, int b)
        {
            Console.WriteLine("di 0");
            if (a == 0 && b == 0)
            {
                Console.WriteLine("di x");
                return 0;
            }
            return await Task.Run(async () =>
            {
                Console.WriteLine("di 1");
                await Task.Delay(2000);
                Console.WriteLine("di 2");
                return a + b;
            });
        }
        async Task<int> UploadPicturesAsync(List<object> imageList, IProgress<int> progress, CancellationToken ct)
        {
            try
            {
                int totalCount = imageList.Count;
                int processCount = await Task.Run<int>(() =>
                {
                    int tempCount = 0;
                    foreach (var image in imageList)
                    {
                        //await the processing and uploading logic here
                        //int processed = await UploadAndProcessAsync(image);
                        // 异步上传/下载方法
                        bool success = Task.Run(async () =>
                                  {
                                      await Task.Delay(2000);
                                      return image.ToString() == "取消" ? false : true;
                                  }).Result;
                        if (ct.IsCancellationRequested)     //判断是否取消
                        {
                            ct.ThrowIfCancellationRequested();
                        }  
                        if (progress != null)
                        {
                            progress.Report((tempCount * 100 / totalCount));
                        }
                        tempCount++;
                    }

                    return tempCount;
                });
                return processCount;
            }
            catch (OperationCanceledException ex)
            {    
                throw ex;
            }
        }
        // 向应该被取消的 System.Threading.CancellationToken 发送信号
        // cts.Token 传播有关应取消操作的通知。
        CancellationTokenSource cts = new CancellationTokenSource();
        /// <summary>
        /// 进度条 异步上传   异步上传button
        /// </summary>
        public async void ProgressBar()
        {
            //construct Progress<T>, passing ReportProgress as the Action<T> 
            //Progress 提供调用每个报告进度的值的回调的 
            var progressIndicator = new Progress<int>(ReportProgress);
            //call async method
            // 模拟上传/下载文件
            List<object> files = new List<object>
            {
                1,2,"取消",3,4,5,2,4,11
            };
            try
            {
                int uploads = await UploadPicturesAsync(files, progressIndicator, cts.Token);
                Console.WriteLine($"upload Count=>{uploads}");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"上传已取消:{ex.Message}");
            }
        }
        /// <summary>
        /// UI线程交互
        /// </summary>
        /// <param name="value"></param>
        void ReportProgress(int value)
        {
            //UI 线程显示进度信息
            Console.WriteLine($"{value}%");
            if (value == 33)   //模拟 取消按钮处理
            {
                cts.Cancel();
            }
            //Update the UI to reflect the progress value that is passed back.
        }
    }
}

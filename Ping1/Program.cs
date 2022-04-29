using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation; //Pingクラス収録

namespace Ping1
{
    class Program
    {
        static void Main(string[] args)
        {

            var ping = new Ping();
            var replies = new List<PingReply>();

            //Pingリクエストの送信と結果の格納(5回行う)
            for (int i = 0; i < 5; i++)
            {
                var reply = ping.Send("www.netkeiba.com");
                replies.Add(reply);
            }

            //Pingの返答が正しい       => StatusプロパティでIPStatus列挙のSuccessを返す
            //Pingの返答が正しくない   => Falseを返す
            var isSucceded = replies.Any(reply => reply.Status == IPStatus.Success);
            Console.WriteLine($"ping succeeded is {isSucceded}");

            //時間がどれだけかかったか知りたい場合はRoundtripTimeプロパティで取得
            var averageTime = replies.Average(reply => reply.RoundtripTime);
            Console.WriteLine($"ping average time is {averageTime}");

            //wait
            Console.ReadLine();
        }
    }
}
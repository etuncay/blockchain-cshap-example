using System;
using Newtonsoft.Json;

namespace BlockChainTutorial1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCoin = new Blockchain();

            char[] h = new char[3 + 1];
            String s = new String(h);
            s = s.Replace("\0", "0");

            Console.Write("Mining Block 1");
            myCoin.addBlock(new Block(1, DateTime.Parse("2017-07-10"),new priceModel{price=4.0}));
            Console.Write("Mining Block 2");
            myCoin.addBlock(new Block(2, DateTime.Parse("2017-07-12"), new priceModel { price = 10.0 }));


            foreach (var item in myCoin.chain)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            }


            //myCoin.chain[1].data = 12.0;
            //myCoin.chain[1].hash = myCoin.chain[1].calculateHash();

            //foreach (var item in myCoin.chain)
            //{
                //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            //}

            Console.ReadKey();
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace BlockChainTutorial1
{
    public class Block
    {
        public int index;
        public DateTime timestamp;
        public object data = new object();
        public string previousHash;
        public string hash;
        public int nonce;
        public Block(int _index, DateTime _timestamp, object _data, string _previousHash="")
        {
            index = _index;
            timestamp = _timestamp;
            data = _data;
            previousHash = _previousHash;
            hash = calculateHash();
            nonce = 0;
        }


        public string calculateHash(){

            using(var sha256 = SHA256.Create())  
            {
                var hashedBytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(index + previousHash + timestamp + Newtonsoft.Json.JsonConvert.SerializeObject(data) + this.nonce)
                );  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }  
        }

        public void mineBlock(int difficulty)
        {
            String s = new String(new char[difficulty]);
            s = s.Replace("\0", "0");
            while (hash.Substring(0,difficulty)!=s){
                this.nonce++;
                this.hash = this.calculateHash();
            }
            Console.Write("Block Mining"+hash);
        }
    }
}

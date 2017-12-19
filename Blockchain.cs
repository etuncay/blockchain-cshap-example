using System;
using System.Collections.Generic;
namespace BlockChainTutorial1
{
    public class Blockchain
    {
        public List<Block> chain = new List<Block>();
        private int difficulty = new int();
        public Blockchain()
        {
            chain.Add(createGenesisBlock());
            difficulty = 5;
        }

        public Block createGenesisBlock(){
            return new Block(0, DateTime.Parse("2017-01-01"), "Genesis block", "0");
        }

        public Block getLatestBlock(){
            return chain[this.chain.Count - 1];
        }

        public void  addBlock(Block newBlock){
            newBlock.previousHash = getLatestBlock().hash;
            newBlock.mineBlock(difficulty);
            chain.Add(newBlock);
        }

        public bool isChainValid(){
            for (var i = 1; i < chain.Count;i++){
                var currentBlock = chain[i];
                var previousBlock = chain[i - 1];

                if(currentBlock.hash != currentBlock.calculateHash()){
                    return false;
                }

                if(currentBlock.previousHash!=previousBlock.hash){
                    return false;
                }
            }

            return true;
        }
    }
}

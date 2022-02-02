using AL.DataEntities;
using Newtonsoft.Json;

namespace AL.DataGenerator
{
    public class BigFileCreator
    {
        private readonly RandomPersonCreator _randomPersonCreator;
        public BigFileCreator()
        {
            _randomPersonCreator = new RandomPersonCreator();
        }
        public void CreateBigFile(string filePath, int numberOfRecords, bool appendToFile)
        {
            if (numberOfRecords == 0) return;

            //track records to write to file in batches
            var recordList = new List<string>();
            var firstWrite = true;

            //used for creating a valid json file
            //using(var writer = new StreamWriter(filePath, appendToFile))
            //{
            //    writer.WriteLine("[");
            //    for(var i = 0; i < numberOfRecords; i++)
            //    {
            //        var person = _randomPersonCreator.CreateRandomPerson();
            //        recordList.Add(JsonConvert.SerializeObject(person));
            //        if(recordList.Count >= 100000)
            //        {
                        
            //            recordList.ForEach(record =>
            //            {
            //                if (firstWrite)
            //                {
            //                    writer.WriteLine($"{record}");
            //                    firstWrite = false;
            //                }
            //                else
            //                {
            //                    writer.WriteLine($",{record}");
            //                }
                            
            //            });
            //            recordList.Clear();
            //        }
            //    }
            //    if (recordList.Count > 0)
            //    {
            //        recordList.ForEach(record => writer.WriteLine($",{record}"));
            //        recordList.Clear();
            //    }
            //    writer.WriteLine("]");
            //}

            using (var writer = new StreamWriter(filePath, appendToFile))
            {
                for (var i = 0; i < numberOfRecords; i++)
                {
                    var person = _randomPersonCreator.CreateRandomPerson();
                    recordList.Add(JsonConvert.SerializeObject(person));
                    if (recordList.Count >= 100000)
                    {

                        recordList.ForEach(record => writer.WriteLine($"{record}"));
                        recordList.Clear();
                    }
                }
                if (recordList.Count > 0)
                {
                    recordList.ForEach(record => writer.WriteLine($"{record}"));
                    recordList.Clear();
                }
            }
        }
    }
}
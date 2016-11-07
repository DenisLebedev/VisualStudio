using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Serialization
    {
        public Serialization()
        {

        }

        public void Serializable(TicTacGame game)
        {
            {
                Console.WriteLine();

                try
                {
                    //create a FileStream to write the serialized output
                    //to a file on our hard drive
                    FileStream fileStream = new FileStream(@"Sample.dat", FileMode.Create);

                    //create a BinaryFormatter object to serialize our object
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, game);
                    fileStream.Close();
                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Catch: " + ioe.Message);
                }
            }
        }

        public TicTacGame Deserializable()
        {
            TicTacGame game = null;

            try
            {
                //c:\Temp\Sample.dat
                //create a FileStream to read the serialized object
                FileStream fileStream = new FileStream(@"Sample.dat", FileMode.Open);

                //create a BinaryFormatter and deserialize the object
                BinaryFormatter formatter = new BinaryFormatter();

                TicTacGame deserializedSample = (TicTacGame)formatter.Deserialize(fileStream);

                Console.WriteLine("The deserialized object:");
                Console.WriteLine(String.Format("Name: {0}", deserializedSample.IA));
                Console.WriteLine(String.Format("PointPl1: {0}", deserializedSample.PointPl1.ToString()));
                Console.WriteLine(String.Format("PointPl2: {0}", deserializedSample.PointPl2.ToString()));
                Console.WriteLine(String.Format("Draw: {0}", deserializedSample.Draw.ToString()));

                game = deserializedSample;

                fileStream.Close();

            }
            catch (IOException ioe)
            {
                Console.WriteLine("Catch: " + ioe.Message);
            }

            return game;
        }
    }
}

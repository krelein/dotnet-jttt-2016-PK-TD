using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace DemotMail
{
    public class ListaZadan
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        virtual public BindingList<Zadanie> Lista { get; set; }

        public ListaZadan() { Lista = new BindingList<Zadanie>(); }

        public void Serialize()
        {
            FileStream fs = new FileStream("Datafile.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, Lista);
                LogFile.AddLog("wykonano serializacje");
            }
            catch (SerializationException e)
            {
                LogFile.AddLog("serializacja nie powiodla sie" + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public void Deserialize()
        {
            FileStream fs = new FileStream("Datafile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Lista = (BindingList<Zadanie>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                LogFile.AddLog("deserializacja nie powiodla sie" + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }


    }
}

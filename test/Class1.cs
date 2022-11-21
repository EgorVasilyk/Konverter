using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace test
{
    internal class Figure
    {
        public string Name;
        public string Color;
        public int Coord;
        public string Format;
        public string path;
        public string text;
        Figure figure;


        public void Read()
        {
            path = Console.ReadLine();
            text = File.ReadAllText(path);
            
        }
        private void Json()
        {
            List<Figure> result = JsonConvert.DeserializeObject<List<Figure>>(text);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        private void Xml()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Figure));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                figure = (Figure)xml.Deserialize(fs);
            };
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, path);
                File.WriteAllText(path, xml);
            }
        }
    }
}

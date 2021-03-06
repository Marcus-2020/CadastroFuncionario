using System.IO;
using System.Xml.Serialization;

namespace CadastroFuncionario.API.Helpers
{
    public static class ClonarObjetoHelper
    {
        public static T ClonarObjeto<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(ms);
            }
        }
    }
}
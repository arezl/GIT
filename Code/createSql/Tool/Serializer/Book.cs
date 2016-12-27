using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
 

namespace createSql.Tool.Serializer
{
        [DataContract]
       class Book
       {
           [DataMember]
          public int ID { get; set; }
   
          [DataMember]
         public string Name { get; set; }
 
          [DataMember]
         public float Price { get; set; }
    }
}

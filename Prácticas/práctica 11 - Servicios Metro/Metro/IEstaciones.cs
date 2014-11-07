using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Metro
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEstaciones" in both code and config file together.
    [ServiceContract]
    public interface IEstaciones
    {
        [OperationContract]
        void DoWork();

        [OperationContract]

        List<DataSocialPresenteDC> GetAllEstaciones();
    }
}

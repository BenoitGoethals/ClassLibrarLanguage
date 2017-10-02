using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibrarLanguage.model;

namespace ClassLibrarLanguage
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IQuestionsService" in both code and config file together.
    [ServiceContract]
    public interface IQuestionsService
    {
        [OperationContract]
        Session MakeSession(DateTime dateTime,Student student);
    }
}

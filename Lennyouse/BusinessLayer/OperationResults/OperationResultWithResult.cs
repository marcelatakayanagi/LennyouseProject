using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.RD.Lennyouse.BusinessLayer.OperationResults
{
    public class OperationResult<T>:OperationResult
    {
        public T Result { get; set; }
    }
}

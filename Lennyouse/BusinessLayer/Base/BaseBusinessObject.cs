using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.Base
{
    public class BaseBusinessObject
    {
        //public void Exemple()
        //{
        //    Console.WriteLine("This is an example");
        //}

        //public void ExempleInTransaction()
        //{
        //    Action exemple = Exemple;
        //    ExecuteOperation(exemple);
        //}





        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };
        
        protected OperationResult ExecuteOperation(Action operation)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                operation.Invoke();
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        protected async Task<OperationResult> ExecuteOperationAsync(Func<Task> operation)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await operation.Invoke();
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        protected OperationResult<TR> ExecuteOperation<TR>(Func<TR> operation)
        {
            try
            {
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, opts,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = operation.Invoke();
                transactionScope.Complete();
                return new OperationResult<TR>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<TR>() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult<TR>> ExecuteOperationAsync<TR>(Func<Task<TR>> operation)
        {
            try
            {
                var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                var res = await operation.Invoke();
                scope.Complete();
                return new OperationResult<TR>() { Success = true , Result = res};
            }
            catch (Exception e)
            {
                return new OperationResult<TR>() { Success = false, Exception = e };
            }
        }
    }
}

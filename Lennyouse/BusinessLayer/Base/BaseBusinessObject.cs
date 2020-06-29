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

        #region Transaction
        protected OperationResult ExecuteTransaction(Action operation)
        {
            var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                 TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                operation.Invoke();
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        protected OperationResult<TR> ExecuteTransaction<TR>(Func<TR> operation)
        {
            var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                 TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var res = operation.Invoke();
                scope.Complete();
                return new OperationResult<TR>() { Success = true , Result = res};
            }
            catch (Exception e)
            {
                return new OperationResult<TR>() { Success = false, Exception = e };
            }

        }
        #endregion

        #region Transaction Async
        protected async Task<OperationResult> ExecuteTransactionAsync(Func<Task> operation)
        {
            var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                 TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                await operation.Invoke();
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        protected async Task<OperationResult<TR>> ExecuteTransactionAsync<TR>(Func<Task<TR>> operation)
        {
            var scope = new TransactionScope(TransactionScopeOption.Required, opts,
                                 TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var res = await operation.Invoke();
                scope.Complete();
                return new OperationResult<TR>() { Success = true , Result = res};
            }
            catch (Exception e)
            {
                return new OperationResult<TR>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Operation
        protected OperationResult ExecuteOperation(Action operation)
        {
            try
            {
                operation.Invoke();
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
                var res = operation.Invoke();
                return new OperationResult<TR>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<TR>() { Success = false, Exception = e };
            }

        }
        #endregion

        #region Operation Async
        protected async Task<OperationResult> ExecuteOperationAsync(Func<Task> operation)
        {
            try
            {
                await operation.Invoke();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<TR>> ExecuteOperationAsync<TR>(Func<Task<TR>> operation)
        {
            try
            {
                var res = await operation.Invoke();
                return new OperationResult<TR>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<TR>() { Success = false, Exception = e };
            }
        }
        #endregion

    }
}

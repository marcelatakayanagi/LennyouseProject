using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO
{
    public class CourseBusinessObject
    {
        private CourseDataAccessObject _dao;
        public CourseBusinessObject()
        {
            _dao = new CourseDataAccessObject();
        }

        #region Create
        public OperationResult Create(Course item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Create(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> CreateAsync(Course item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.CreateAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Course> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Course>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Course>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Course>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Course>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Course>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Course item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Update(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(Course item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.UpdateAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Course item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Delete(item);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(Course item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.DeleteAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }


        public OperationResult Delete(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                _dao.Delete(id);
                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.DeleteAsync(id);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List
        public OperationResult<List<Course>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.List();
                transactionScope.Complete();
                return new OperationResult<List<Course>> () { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Course>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Course>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                            TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Course>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Course>>() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}

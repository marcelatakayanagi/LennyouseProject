using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfoBO
{
    public class ServingBusinessObject
    {
        private ServingDataAccessObject _dao;
        public ServingBusinessObject()
        {
            _dao = new ServingDataAccessObject();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };


        #region Create
        public OperationResult Create(Serving serving)
        {
            try
            {
                _dao.Create(serving);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> CreateAsync(Serving serving)
        {
            try
            {

                await _dao.CreateAsync(serving);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Serving> Read(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    ts.Complete();
                    return new OperationResult<Serving>() { Success = true, Result = res };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<Serving>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Serving>> ReadAsync(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ReadAsync(id);
                    ts.Complete();
                    return new OperationResult<Serving>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<Serving>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Serving serving)
        {
            try
            {
                _dao.Update(serving);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(Serving serving)
        {
            try
            {
                await _dao.UpdateAsync(serving);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Serving serving)
        {
            try
            {
                _dao.Delete(serving);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(Serving serving)
        {
            try
            {
                await _dao.DeleteAsync(serving);
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

                _dao.Delete(id);

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
                await _dao.DeleteAsync(id);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List
        public OperationResult<List<Serving>> List()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<Serving>>() { Success = true, Result = result };
                }


            }
            catch (Exception e)
            {
                return new OperationResult<List<Serving>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Serving>>> ListAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<Serving>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<Serving>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region CountAll

        public OperationResult<int> CountAll()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List().Count;
                    ts.Complete();
                    return new OperationResult<int>() { Success = true, Result = _dao.List().Count };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<int>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<int>> CountAllAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<int>() { Success = true, Result = result.Count };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<int>() { Success = false, Exception = e };
            }
        }


        #endregion
    }
}
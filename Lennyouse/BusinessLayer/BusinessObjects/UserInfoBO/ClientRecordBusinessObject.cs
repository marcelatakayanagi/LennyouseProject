using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfoBO
{
    public class ClientRecordBusinessObject
    {
        private ClientRecordDataAccessObject _dao;
        public ClientRecordBusinessObject()
        {
            _dao = new ClientRecordDataAccessObject();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region List
        public OperationResult<List<ClientRecord>> List()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<ClientRecord>>() { Success = true, Result = result };
                }


            }
            catch (Exception e)
            {
                return new OperationResult<List<ClientRecord>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<ClientRecord>>> ListAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<ClientRecord>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<ClientRecord>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(ClientRecord item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> CreateAsync(ClientRecord item)
        {
            try
            {
                await _dao.CreateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<ClientRecord> Read(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    ts.Complete();
                    return new OperationResult<ClientRecord>() { Success = true, Result = res };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<ClientRecord>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<ClientRecord>> ReadAsync(Guid id)
        {
            try
            {
                using var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                ts.Complete();
                return new OperationResult<ClientRecord>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<ClientRecord>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(ClientRecord item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(ClientRecord item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(ClientRecord item)
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> DeleteAsync(ClientRecord item)
        {
            try
            {
                await _dao.DeleteAsync(item);
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
    }
}

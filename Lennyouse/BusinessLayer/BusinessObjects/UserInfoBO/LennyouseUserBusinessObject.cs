using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfoDAO;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfoBO
{
    public class LennyouseUserBusinessObject
    {
        private LennyouseUserDataAccessObject _dao;

        public LennyouseUserBusinessObject()
        {
            _dao = new LennyouseUserDataAccessObject();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region List
        public OperationResult<List<LennyouseUser>> List()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<LennyouseUser>>() { Success = true, Result = result };
                }


            }
            catch (Exception e)
            {
                return new OperationResult<List<LennyouseUser>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<LennyouseUser>>> ListAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<LennyouseUser>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<LennyouseUser>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(LennyouseUser item)
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

        public async Task<OperationResult> CreateAsync(LennyouseUser item)
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
        public OperationResult<LennyouseUser> Read(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    ts.Complete();
                    return new OperationResult<LennyouseUser>() { Success = true, Result = res };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<LennyouseUser>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<LennyouseUser>> ReadAsync(Guid id)
        {
            try
            {
                using var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                ts.Complete();
                return new OperationResult<LennyouseUser>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<LennyouseUser>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(LennyouseUser item)
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

        public async Task<OperationResult> UpdateAsync(LennyouseUser item)
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
    }
}

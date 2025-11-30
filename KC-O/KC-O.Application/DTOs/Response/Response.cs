using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Response
{
    public static class Response<T>
    {
        public static ResponseModel<T> SaveSuccess()
        {
            return new ResponseModel<T> 
            { 
                Status = true, 
                Message = ResponseStringResources.SAVE_SUCCESS 
            };
        }

        public static ResponseModel<T> SaveFailed()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.SAVE_FAILED };
        }

        public static ResponseModel<T> UpdateSuccess()
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.DATA_UPDATED };
        }

        public static ResponseModel<T> UpdateFailed()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.UPDATE_FAILED };
        }

        public static ResponseModel<T> DeleteSuccess()
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.DATA_DELETED };
        }

        public static ResponseModel<T> DeleteFailed()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.DELETE_FAILED };
        }

        public static ResponseModel<T> ActiveOrInActiveSuccess(bool is_active = true)
        {
            return new ResponseModel<T> { Status = true, Message = is_active ? ResponseStringResources.ACTIVE : ResponseStringResources.INACTIVE };
        }

        public static ResponseModel<T> ActiveOrInActiveFailed(bool is_active = true)
        {
            return new ResponseModel<T> { Status = false, Message = is_active ? ResponseStringResources.ACTIVE_FAILED : ResponseStringResources.INACTIVE_FAILED };
        }

        public static ResponseModel<T> ApproveOrUnApproveSuccess(bool is_approve = false)
        {
            return new ResponseModel<T> { Status = true, Message = is_approve ? ResponseStringResources.APPROVED_SUCCESSFUL : ResponseStringResources.UNAPPROVED_SUCCESSFUL };
        }

        public static ResponseModel<T> ApproveOrUnApproveFailed(bool is_approve = false)
        {
            return new ResponseModel<T> { Status = false, Message = is_approve ? ResponseStringResources.APPROVED_FAILED : ResponseStringResources.UNAPPROVED_FAILED };
        }

        public static ResponseModel<T> ApproveSuccess()
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.APPROVED_SUCCESSFUL };
        }

        public static ResponseModel<T> ApproveFailed()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.APPROVED_FAILED };
        }

        public static ResponseModel<T> UnApproveSuccess()
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.UNAPPROVED_SUCCESSFUL };
        }

        public static ResponseModel<T> UnApproveFailed()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.UNAPPROVED_FAILED };
        }

        public static ResponseModel<T> DataFound(T data)
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.DATA_FOUND, Data = data };
        }

        public static ResponseModel<T> DisbursementUpload(T data)
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.DISBURSEMENT_UPLOADED, Data = data };
        }

        public static ResponseModel<T> DataNotFound()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.NO_DATA_FOUND };
        }

        public static ResponseModel<T> DataNotFound(T data)
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.NO_DATA_FOUND, Data = data };
        }

        public static ResponseModel<T> DataExist()
        {
            return new ResponseModel<T> { Status = true, Message = ResponseStringResources.DATA_EXIST };
        }

        public static ResponseModel<T> DataNotExist()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.DATA_NOT_EXIST };
        }

        public static ResponseModel<T> CustomMessage(bool status, string message, T? data)
        {
            return new ResponseModel<T> { Status = status, Message = message, Data = data };
        }

        public static ResponseModel<T> CustomMessage(bool status, string message)
        {
            return new ResponseModel<T> { Status = status, Message = message };
        }

        public static ResponseModel<T> InvalidParameter()
        {
            return new ResponseModel<T> { Status = false, Message = ResponseStringResources.Invalid_Parameter };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.Constant
{
    public abstract class ResponseStringResources
    {
        public const string DATA_FOUND = "Data found";
        public const string NO_DATA_FOUND = "No data found";
        public const string DATA_EXIST = "Data already exists";
        public const string USER_EXIST = "User already exists";
        public const string DATA_NOT_EXIST = "Data not exist";
        public const string SAVE_SUCCESS = "Data saved successfully";
        public const string SAVE_FAILED = "Failed to Save Data";
        public const string DATA_UPDATED = "Data Updated Successfully";
        public const string UPDATE_FAILED = "Failed to Update Data";
        public const string DATA_DELETED = "Data Deleted Successfully";
        public const string DELETE_FAILED = "Failed to Delete Data";
        public const string ACTIVE = "Data Active Successfully";
        public const string POPULAR = "Data Popular Successfully";
        public const string ACTIVE_FAILED = "Failed to Active Data";
        public const string POPULAR_FAILED = "Failed to Popular Data";
        public const string INACTIVE = "Data InActive Successfully";
        public const string NOTPOPULAR = "Data Not Popular Successfully";
        public const string INACTIVE_FAILED = "Failed to InActive Data";
        public const string NOTPOPULAR_FAILED = "Failed to Not Popular Data";
        public static string APPROVED_SUCCESSFUL = "Approved Successful";
        public static string APPROVED_FAILED = "Failed to Approve";
        public static string UNAPPROVED_SUCCESSFUL = "UnApproved Successful";
        public static string UNAPPROVED_FAILED = "Failed to UnApprove";
        public static string RIDER_EXIST = "Rider with same mobile number is exist!";
        public static string NOTHING_TODO = "Nothing to do!";
        public static string INACTIVE_DATA = "Data is inactive!";
        public const string Mobile_Number_EXIST = "Mobile Number already exists";
        public const string DISBURSEMENT_UPLOADED = "Disbursement uploaded successfully!";
        public const string EIGHTEEN_PLUS = "Your age must be 18+";

        public const string SUCCESS = "Success";
        public const string ERROR = "Error Occured";
        public const string SOMETHING_WENT_WRONG = "Something Went Wrong";
        public const string EXECPTION = "Internal Server Error ";
        public const string ReferredCodeNotExist = "Invalid Referral Code";
        public const string Rider_Already_Suspended = "Rider already suspended";
        public const string Invalid_Parameter = "Invalid Parameter";

        public const string DATETIME_ISO_FORMAT = "yyyy-MM-ddTHH:mm:ssZ";

        public const string LOG_ERROR = "error";
        public const string LOG_WARNING = "warning";
        public const string LOG_INFO = "info";
        public const string SWAP_REQUEST_FAILED = "Failed to Swap Request";
        public const string SWAPPING_TIMEOUT = "Swapping time out";
        public const string SHIFT_STARTED = "Shift started";
        public const string HANGFIRE_SCHEDULER_CREATE_FAILED = "Hangfire failed to create scheduler for this shift please try again to create from action button!";

        //// Payment
        //public const string DISBURSEMENT_BKASH = "BKASH";
        //public const string DISBURSEMENT_UPAY = "UPAY";
        //public const string DISBURSEMENT_SUCCCSS = "SUCCESS";


        //public const string SETUP_NOT_EXIST = "Setup not exist for this rider";
        //public const string DUE_LIMIT_EXCEED = "Your due amount limit is exceeded. Please repay the due amount";

        //public const string NOT_WEEKDAY = "This is not the day to withdraw";
        //public const string COUNT_LIMIT_EXCEED = "Your withdrawal time limit is exceeded. Please try again tomorrow.";
        //public const string NO_DUE_EXIST = "No due amount exist for this rider";
        //public const string CAN_BE_WITHDRAWN = "Can be withdrawn";
        //public const string INVALID_AMOUNT = "Invalid amount!!!";
        //public const string RIDER_NOT_FOUND = "Rider not found by given Id.";

        //public const string DUE_LIMIT_NEGATIVE = "Due limit can not be negative.";
        //public static string CONSUMER_CREATED = "RMQ Consumer created";
        //public static string MESSAGE_RECEIVED = "RMQ message received";
        //public static string CONSUMER_RECEIVED_FAILED = "Consumer Received Failed";
        //public static string PROCESS_START = "Process Start";
        //public static string PROCESS_COMPLETE = "Process Complete";
        //public static string PROCESS_FAILED = "Process Failed";
        //public const string REQUESTED = "Request Sent successfully";
        //public const string REQUEST_FAILED = "Request Sent failed";
        //public const string VALIDATION_SUCCESS = "Validation Success!";
        //public const string VALIDATION_FAILED = "Validation failed";
        //public const string FAILED_TRANSECTION = "Transection failed";
        //public const string COMPLETED_TRANSECTION = "Transection completed";
        //public const string TRANSECTION_IN_PROGRESS = "Transection in-progress";
        //public const string TRANSECTION_EXIST = "You already have one transaction in progress!!!";
        //public const string TRANSECTION_INIT_GRPC_RESPONSE = "Transection init Grpc init response!";
        //public const string REQUEST_RECEIVED = "Request Received.";

        //// Bonus Type
        //public const string REFERRAL_BONUS = "Referral";
        //public const string JOINING_BONUS = "Joining";

    }
}

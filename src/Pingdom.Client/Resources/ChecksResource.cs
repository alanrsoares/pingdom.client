namespace PingdomClient.Resources
{
    using Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class ChecksResource : Resource
    {
        internal ChecksResource() { }

        /// <summary>
        /// Returns a list overview of all checks.
        /// </summary>
        /// <returns></returns>
        public Task<GetCheckListResponse> GetChecksList()
        {
            return Client.GetAsync<GetCheckListResponse>("checks/");
        }

        /// <summary>
        /// Returns a detailed description of a specified check.
        /// </summary>
        /// <param name="checkId"></param>
        /// <returns></returns>
        public Task<GetDetailedCheckInformationResponse> GetDetailedCheckInformation(int checkId)
        {
            return Client.GetAsync<GetDetailedCheckInformationResponse>(string.Format("checks/{0}", checkId));
        }

        /// <summary>
        /// Creates a new check with settings specified by provided parameters.
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public Task<CreateNewCheckResponse> CreateNewCheck(object check)
        {
            return Client.PostAsync<CreateNewCheckResponse>("checks/", check);
        }

        /// <summary>
        /// Modify settings for a check. The provided settings will overwrite previous values. 
        /// Settings not provided will stay the same as before the update. To clear an existing value, 
        /// provide an empty value. Please note that you cannot change the type of a check once it has been created.
        /// </summary>
        /// <param name="checkId"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public Task<PingdomResponse> ModifyCheck(int checkId, object check)
        {
            return Client.PutAsync<PingdomResponse>(string.Format("checks/{0}", checkId), check);
        }

        /// <summary>
        /// Pause or change resolution for multiple checks in one bulk call.
        /// </summary>
        /// <param name="modifyMultipleChecksRequest"></param>
        /// <returns></returns>
        public Task<string> ModifyMultipleChecks(object modifyMultipleChecksRequest)
        {
            return Client.PutAsync<string>("checks/", modifyMultipleChecksRequest);
        }

        /// <summary>
        /// Deletes a check. THIS METHOD IS IRREVERSIBLE! You will lose all collected data. Be careful!
        /// </summary>
        /// <param name="checkId"></param>
        /// <returns></returns>
        public Task<PingdomResponse> DeleteCheck(int checkId)
        {
            return Client.DeleteAsync<PingdomResponse>(string.Format("checks/{0}", checkId));
        }

        /// <summary>
        /// Deletes a list of checks. THIS METHOD IS IRREVERSIBLE! You will lose all collected data. Be careful!
        /// </summary>
        /// <param name="checkIds"></param>
        /// <returns></returns>
        public Task<PingdomResponse> DeleteMultipleChecks(IEnumerable<int> checkIds)
        {
            return Client.DeleteAsync<PingdomResponse>("checks/", new { checkIds = string.Join(",", checkIds) });
        }
    }
}
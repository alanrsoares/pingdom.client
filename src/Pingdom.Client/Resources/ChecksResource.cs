namespace PingdomClient.Resources
{
    using Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public sealed class ChecksResource : Resource
    {
        internal ChecksResource() { }

        public Task<GetCheckListResponse> GetChecksList()
        {
            return Client.GetAsync<GetCheckListResponse>("checks/");
        }

        public Task<GetDetailedCheckInformationResponse> GetDetailedCheckInformation(int checkId)
        {
            return Client.GetAsync<GetDetailedCheckInformationResponse>(string.Format("checks/{0}", checkId));
        }

        public Task<CreateNewCheckResponse> CreateNewCheck(object check)
        {
            return Client.PostAsync<CreateNewCheckResponse>("checks/", check);
        }

        public Task<PingdomResponse> ModifyCheck(int checkId, object check)
        {
            return Client.PutAsync<PingdomResponse>(string.Format("checks/{0}", checkId), check);
        }

        public Task<string> ModifyMultipleChecks(object modifyMultipleChecksRequest)
        {
            return Client.PutAsync<string>("checks/", modifyMultipleChecksRequest);
        }

        public Task<PingdomResponse> DeleteCheck(int checkId)
        {
            return Client.DeleteAsync<PingdomResponse>(string.Format("checks/{0}", checkId));
        }

        public Task<PingdomResponse> DeleteMultipleChecks(IEnumerable<int> checkIds)
        {
            return Client.DeleteAsync<PingdomResponse>("checks/", new { checkIds = string.Join(",", checkIds) });
        }
    }
}
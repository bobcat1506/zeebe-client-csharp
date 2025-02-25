using Zeebe.Client.Api.Responses;

namespace Zeebe.Client.Api.Commands
{
    public interface IUpdateRetriesCommandStep1
    {
        /// <summary>
        ///   Set the retries of this job.
        ///
        /// <p>If the given retries are greater than zero then this job will be picked up again by a job
        /// subscription and a related incident will be marked as resolved.
        /// </summary>
        /// <param name="retries">retries the retries of this job</param>
        /// <returns>
        /// the builder for this command. Call #Send() to complete the command and send it to the broker.
        /// </returns>
        IUpdateRetriesCommandStep2 Retries(int retries);
    }

    public interface IUpdateRetriesCommandStep2 : IFinalCommandStep<IUpdateRetriesResponse>
    {
    // the place for new optional parameters
    }
}
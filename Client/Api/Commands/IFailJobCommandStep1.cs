﻿//
//    Copyright (c) 2018 camunda services GmbH (info@camunda.com)
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using Zeebe.Client.Api.Responses;

namespace Zeebe.Client.Api.Commands
{
    public interface IFailJobCommandStep1
    {
        /// <summary>
        /// Set the remaining retries of this job.
        ///
        /// <p>If the retries are greater than zero then this job will be picked up again by a job
        /// worker. Otherwise, an incident is created for this job.
        /// </p>
        /// </summary>
        ///
        /// <param name="remainingRetries">the remaining retries of this job (e.g. "jobEvent.getRetries() - 1")</param>
        /// <returns>the builder for this command. Call {@link #Send()} to complete the command and send it
        ///     to the broker.
        ///     </returns>
        IFailJobCommandStep2 Retries(int remainingRetries);
    }

    public interface IFailJobCommandStep2 : IFinalCommandStep<IFailJobResponse>
    {
        /// <summary>
        /// Set the error message of this failing job.
        ///
        /// <p>If the retries are zero then this error message will be used for the incident creation.
        ///
        /// </summary>
        ///
        /// <param name="errorMsg">the error msg for this failing job</param>
        /// <returns>the builder for this command. Call {@link #Send()} to complete the command and send it
        ///     to the broker.
        ///     </returns>
        IFailJobCommandStep2 ErrorMessage(string errorMsg);
    }
}
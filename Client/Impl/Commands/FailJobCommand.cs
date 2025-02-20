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

using System.Threading.Tasks;
using GatewayProtocol;
using Zeebe.Client.Api.Commands;
using Zeebe.Client.Api.Responses;
using static GatewayProtocol.Gateway;
using FailJobResponse = Zeebe.Client.Impl.Responses.FailJobResponse;

namespace Zeebe.Client.Impl.Commands
{
    public class FailJobCommand : IFailJobCommandStep1, IFailJobCommandStep2
    {
        private readonly FailJobRequest request;
        private readonly GatewayClient gatewayClient;

        public FailJobCommand(GatewayClient client, long jobKey)
        {
            gatewayClient = client;
            request = new FailJobRequest
            {
                JobKey = jobKey
            };
        }

        public IFailJobCommandStep2 Retries(int remainingRetries)
        {
            request.Retries = remainingRetries;
            return this;
        }

        public IFailJobCommandStep2 ErrorMessage(string errorMsg)
        {
            request.ErrorMessage = errorMsg;
            return this;
        }

        public async Task<IFailJobResponse> Send()
        {
            var asyncReply = gatewayClient.FailJobAsync(request);
            await asyncReply.ResponseAsync;
            return new FailJobResponse();
        }
    }
}

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

namespace Zeebe.Client.Impl.Commands
{
    internal class CompleteJobCommand : ICompleteJobCommandStep1
    {
        private readonly CompleteJobRequest request;
        private readonly GatewayClient gatewayClient;

        public CompleteJobCommand(GatewayClient client, long jobKey)
        {
            gatewayClient = client;
            request = new CompleteJobRequest
            {
                JobKey = jobKey
            };
        }

        public ICompleteJobCommandStep1 Variables(string variables)
        {
            request.Variables = variables;
            return this;
        }

        public async Task<ICompleteJobResponse> Send()
        {
            var asyncReply = gatewayClient.CompleteJobAsync(request);
            await asyncReply.ResponseAsync;
            return new Responses.CompleteJobResponse();
        }
    }
}

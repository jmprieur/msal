﻿// ------------------------------------------------------------------------------
// 
// Copyright (c) Microsoft Corporation.
// All rights reserved.
// 
// This code is licensed under the MIT License.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
// ------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Browser;
using Microsoft.Identity.Client.Cache;

namespace Microsoft.Identity.Client.Requests
{
    internal class MsalInteractiveRequest : IMsalInteractiveRequest
    {
        private readonly IBrowserFactory _browserFactory;
        private readonly IRequestDispatcher _requestDispatcher;
        private readonly AuthenticationParameters _authParameters;
        private readonly CacheManager _cacheManager;
        private readonly WebRequestManager _webRequestManager;

        public MsalInteractiveRequest(
            IRequestDispatcher requestDispatcher,
            WebRequestManager webRequestManager,
            CacheManager cacheManager,
            IBrowserFactory browserFactory,
            AuthenticationParameters authParameters)
        {
            _requestDispatcher = requestDispatcher;
            _webRequestManager = webRequestManager;
            _cacheManager = cacheManager;
            _browserFactory = browserFactory;
            _authParameters = authParameters;
        }

        /// <inheritdoc />
        public Task<AuthenticationResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
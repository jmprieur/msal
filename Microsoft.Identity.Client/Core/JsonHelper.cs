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

using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Microsoft.Identity.Client.Core
{
    internal static class JsonHelper
    {
        internal static string SerializeToJson<T>(T toEncode)
        {
            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(stream, toEncode);
                return Encoding.UTF8.GetString(stream.ToArray(), 0, (int)stream.Position);
            }
        }

        internal static T DeserializeFromJson<T>(string json)
        {
            return string.IsNullOrEmpty(json) ? default(T) : DeserializeFromJson<T>(json.ToByteArray());
        }

        private static T DeserializeFromJson<T>(byte[] jsonByteArray)
        {
            if (jsonByteArray == null || jsonByteArray.Length == 0)
            {
                return default(T);
            }

            T response;
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream(jsonByteArray))
            {
                response = (T)serializer.ReadObject(stream);
            }

            return response;
        }
    }
}
/*
 * Copyright (c) 2017 Aspose Pty Ltd. All Rights Reserved.
 *
 * Licensed under the MIT (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *       https://github.com/aspose-omr/Aspose.OMR-for-Cloud/blob/master/LICENSE
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace Com.Aspose.OMR
{
    public class ApiException : Exception
    {

        private int errorCode = 0;

        public ApiException()
        {
        }

        public int ErrorCode
        {
            get { return errorCode; }
        }

        public ApiException(int errorCode, string message) : base(message)
        {
            this.errorCode = errorCode;
        }
    }
}

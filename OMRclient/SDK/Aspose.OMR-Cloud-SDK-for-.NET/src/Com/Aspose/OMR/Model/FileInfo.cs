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
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Com.Aspose.OMR.Model
{
    public class FileInfo
    {
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets file's size
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets file's data
        /// </summary>
        public byte[] Data { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FilesInfo {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");

            sb.Append("}\n");
            return sb.ToString();
        }
    }
}

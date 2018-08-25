// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Gets a list of fabric config versions that are provisioned in a Service Fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFProvisionedFabricConfigVersionInfoList", DefaultParameterSetName = "GetProvisionedFabricConfigVersionInfoList")]
    public partial class GetProvisionedFabricConfigVersionInfoListCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ConfigVersion. The config version of Service Fabric.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "GetProvisionedFabricConfigVersionInfoList")]
        public string ConfigVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "GetProvisionedFabricConfigVersionInfoList")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var result = this.ServiceFabricClient.Cluster.GetProvisionedFabricConfigVersionInfoListAsync(
                    configVersion: this.ConfigVersion,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                foreach (var item in result)
                {
                    this.WriteObject(this.FormatOutput(item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> In some cases the start task may be re-run even though the node was not rebooted. Due to this, start tasks should be idempotent and exit gracefully if the setup they're performing has already been done. Special care should be taken to avoid start tasks which create breakaway process or install/launch services from the start task working directory, as this will block Batch from being able to re-run the start task. </summary>
    public partial class BatchAccountPoolStartTask
    {
        /// <summary> Initializes a new instance of BatchAccountPoolStartTask. </summary>
        public BatchAccountPoolStartTask()
        {
            ResourceFiles = new ChangeTrackingList<BatchResourceFile>();
            EnvironmentSettings = new ChangeTrackingList<BatchEnvironmentSetting>();
        }

        /// <summary> Initializes a new instance of BatchAccountPoolStartTask. </summary>
        /// <param name="commandLine"> The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion. If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux. Required if any other properties of the startTask are specified. </param>
        /// <param name="resourceFiles"> A list of files that the Batch service will download to the compute node before running the command line. </param>
        /// <param name="environmentSettings"> A list of environment variable settings for the start task. </param>
        /// <param name="userIdentity"> If omitted, the task runs as a non-administrative user unique to the task. </param>
        /// <param name="maxTaskRetryCount"> The Batch service retries a task if its exit code is nonzero. Note that this value specifically controls the number of retries. The Batch service will try the task once, and may then retry up to this limit. For example, if the maximum retry count is 3, Batch tries the task up to 4 times (one initial try and 3 retries). If the maximum retry count is 0, the Batch service does not retry the task. If the maximum retry count is -1, the Batch service retries the task without limit. </param>
        /// <param name="waitForSuccess"> If true and the start task fails on a compute node, the Batch service retries the start task up to its maximum retry count (maxTaskRetryCount). If the task has still not completed successfully after all retries, then the Batch service marks the compute node unusable, and will not schedule tasks to it. This condition can be detected via the node state and scheduling error detail. If false, the Batch service will not wait for the start task to complete. In this case, other tasks can start executing on the compute node while the start task is still running; and even if the start task fails, new tasks will continue to be scheduled on the node. The default is true. </param>
        /// <param name="containerSettings"> When this is specified, all directories recursively below the AZ_BATCH_NODE_ROOT_DIR (the root of Azure Batch directories on the node) are mapped into the container, all task environment variables are mapped into the container, and the task command line is executed in the container. </param>
        internal BatchAccountPoolStartTask(string commandLine, IList<BatchResourceFile> resourceFiles, IList<BatchEnvironmentSetting> environmentSettings, BatchUserIdentity userIdentity, int? maxTaskRetryCount, bool? waitForSuccess, BatchTaskContainerSettings containerSettings)
        {
            CommandLine = commandLine;
            ResourceFiles = resourceFiles;
            EnvironmentSettings = environmentSettings;
            UserIdentity = userIdentity;
            MaxTaskRetryCount = maxTaskRetryCount;
            WaitForSuccess = waitForSuccess;
            ContainerSettings = containerSettings;
        }

        /// <summary> The command line does not run under a shell, and therefore cannot take advantage of shell features such as environment variable expansion. If you want to take advantage of such features, you should invoke the shell in the command line, for example using "cmd /c MyCommand" in Windows or "/bin/sh -c MyCommand" in Linux. Required if any other properties of the startTask are specified. </summary>
        public string CommandLine { get; set; }
        /// <summary> A list of files that the Batch service will download to the compute node before running the command line. </summary>
        public IList<BatchResourceFile> ResourceFiles { get; }
        /// <summary> A list of environment variable settings for the start task. </summary>
        public IList<BatchEnvironmentSetting> EnvironmentSettings { get; }
        /// <summary> If omitted, the task runs as a non-administrative user unique to the task. </summary>
        public BatchUserIdentity UserIdentity { get; set; }
        /// <summary> The Batch service retries a task if its exit code is nonzero. Note that this value specifically controls the number of retries. The Batch service will try the task once, and may then retry up to this limit. For example, if the maximum retry count is 3, Batch tries the task up to 4 times (one initial try and 3 retries). If the maximum retry count is 0, the Batch service does not retry the task. If the maximum retry count is -1, the Batch service retries the task without limit. </summary>
        public int? MaxTaskRetryCount { get; set; }
        /// <summary> If true and the start task fails on a compute node, the Batch service retries the start task up to its maximum retry count (maxTaskRetryCount). If the task has still not completed successfully after all retries, then the Batch service marks the compute node unusable, and will not schedule tasks to it. This condition can be detected via the node state and scheduling error detail. If false, the Batch service will not wait for the start task to complete. In this case, other tasks can start executing on the compute node while the start task is still running; and even if the start task fails, new tasks will continue to be scheduled on the node. The default is true. </summary>
        public bool? WaitForSuccess { get; set; }
        /// <summary> When this is specified, all directories recursively below the AZ_BATCH_NODE_ROOT_DIR (the root of Azure Batch directories on the node) are mapped into the container, all task environment variables are mapped into the container, and the task command line is executed in the container. </summary>
        public BatchTaskContainerSettings ContainerSettings { get; set; }
    }
}

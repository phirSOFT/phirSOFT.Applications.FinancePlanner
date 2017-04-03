using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace phirSOFT.Applications.FinancePlanner.ProgressManager.Tests
{
    [TestClass]
    public class ProgressManagerTest
    {
        [TestMethod]
        public async Task AutoRemoveTest1()
        {
            var manager = new Services.ProgressManager();
            var sampleProgress = manager.RegisterProgress(null);
            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Faultet
            });

            await Task.Delay(1000);
            Assert.IsTrue(manager.Progresses.Any());
            await Task.Delay(2500);

            Assert.IsFalse(manager.Progresses.Any());
        }

        [TestMethod]
        public async Task AutoRemoveTest2()
        {
            var manager = new Services.ProgressManager();
            var sampleProgress = manager.RegisterProgress(null);
            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Finished
            });

            await Task.Delay(1000);
            Assert.IsTrue(manager.Progresses.Any());
            await Task.Delay(2500);

            Assert.IsFalse(manager.Progresses.Any());
        }

        [TestMethod]
        public async Task ChangesPropagandation()
        {
            var manager = new Services.ProgressManager();
            var sampleProgress = manager.RegisterProgress(null);

            //Register the Progress
            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Running,
                Title = "Title",
                Description = "Description",
                Progress = 0.2
            });

            while (!manager.Progresses.Any())
            {
                await Task.Delay(200);
            }

            var prg = manager.Progresses.First();
    
            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Intermediate,
                Title = "Title",
                Description = "Description",
                Progress = 0.2
            });

            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Intermediate,
                Title = "Title changed",
                Description = "Description",
                Progress = 0.2
            });

            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Intermediate,
                Title = "Title changed",
                Description = "Description 2",
                Progress = 0.2
            });

            sampleProgress.Report(new ProgressReport
            {
                State = ProgressStates.Intermediate,
                Title = "Title changed",
                Description = "Description 2",
                Progress = 0.4
            });

            //Give some time to propangate the changes
            await Task.Delay(500);

            Assert.AreEqual("Title changed", prg.Title);
            Assert.AreEqual("Description 2", prg.Description);
            Assert.AreEqual(ProgressStates.Intermediate, prg.State);
            Assert.AreEqual(0.4, prg.Progress);



        }


    }
}

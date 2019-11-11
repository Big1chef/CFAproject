using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFA.Services;
using Moq;

namespace CFA.API.Tests.Service
{
    [TestClass]
    public class CFAtest
    {
        private IScoreService _scoreService;
        private string _FakeData;
        [TestInitialize]
        public void Initialize()
        {
            _scoreService = new ScoreService();
            //here we use a single fake data to test the project
            // this should be return a int 9
            _FakeData = "{{{},{}}}";
        }

        [TestMethod]
        public void checkInputFromFakeData()
        {
            int score = 0;
            int level = 0;
            var result = _scoreService.Add(_FakeData, score, level);

            // check the whether the reuslt is 9
            Assert.AreEqual(9, result);
        }

    }
}

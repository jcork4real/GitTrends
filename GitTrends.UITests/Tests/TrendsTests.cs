﻿using System.Linq;
using System.Threading.Tasks;
using GitTrends.Mobile.Shared;
using NUnit.Framework;
using Xamarin.UITest;

namespace GitTrends.UITests
{
    [TestFixture(Platform.Android, UserType.Demo)]
    [TestFixture(Platform.Android, UserType.LoggedIn)]
    [TestFixture(Platform.iOS, UserType.LoggedIn)]
    [TestFixture(Platform.iOS, UserType.Demo)]
    class TrendsTests : BaseTest
    {
        public TrendsTests(Platform platform, UserType userType) : base(platform, userType)
        {
        }

        public override async Task BeforeEachTest()
        {
            await base.BeforeEachTest().ConfigureAwait(false);

            var selectedRepository = RepositoryPage.VisibleCollection.First();

            RepositoryPage.TapRepository(selectedRepository.Name);

            await TrendsPage.WaitForPageToLoad().ConfigureAwait(false);

            Assert.IsTrue(App.Query(selectedRepository.Name).Any());

            Assert.AreEqual(selectedRepository.TotalViews.ConvertToAbbreviatedText(), TrendsPage.ViewsStatisticsLabelText);
            Assert.AreEqual(selectedRepository.TotalUniqueViews.ConvertToAbbreviatedText(), TrendsPage.UniqueViewsStatisticsLabelText);
            Assert.AreEqual(selectedRepository.TotalClones.ConvertToAbbreviatedText(), TrendsPage.ClonesStatisticsLabelText);
            Assert.AreEqual(selectedRepository.TotalUniqueClones.ConvertToAbbreviatedText(), TrendsPage.UniqueClonesStatisticsLabelText);
        }

        [Test]
        public void EnsureCardsAreInteractive()
        {
            //Arrange
            bool isViewsSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalViewsTitle);
            bool isUniqueViewsSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueViewsTitle);
            bool isClonesSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalClonesTitle);
            bool isUniqueClonesSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueClonesTitle);

            //Act
            TrendsPage.TapViewsCard();

            //Assert
            Assert.AreNotEqual(isViewsSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalViewsTitle));

            //Act
            TrendsPage.TapUniqueViewsCard();

            //Assert
            Assert.AreNotEqual(isUniqueViewsSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueViewsTitle));

            //Act
            TrendsPage.TapClonesCard();

            //Assert
            Assert.AreNotEqual(isClonesSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalClonesTitle));

            //Act
            TrendsPage.TapUniqueClonesCard();

            //Assert
            Assert.AreNotEqual(isUniqueClonesSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueClonesTitle));
        }

        [Test]
        public void EnsureLegendIsInteractive()
        {
            //Arrange
            bool isViewsSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalViewsTitle);
            bool isUniqueViewsSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueViewsTitle);
            bool isClonesSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalClonesTitle);
            bool isUniqueClonesSeriesVisible_Initial = TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueClonesTitle);

            //Act
            TrendsPage.TapViewsLegendIcon();

            //Assert
            Assert.AreNotEqual(isViewsSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalViewsTitle));

            //Act
            TrendsPage.TapUniqueViewsLegendIcon();

            //Assert
            Assert.AreNotEqual(isUniqueViewsSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueViewsTitle));

            //Act
            TrendsPage.TapClonesLegendIcon();

            //Assert
            Assert.AreNotEqual(isClonesSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.TotalClonesTitle));

            //Act
            TrendsPage.TapUniqueClonesLegendIcon();

            //Assert
            Assert.AreNotEqual(isUniqueClonesSeriesVisible_Initial, TrendsPage.IsSeriesVisible(TrendsChartConstants.UniqueClonesTitle));
        }
    }
}

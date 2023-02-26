namespace tests.viewmodels
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        MainWindowViewModel vm = new();

        [Test]
        public void UnknownWordDoesNotProduceCombinations()
        {
            // Arrange
            vm.SelectedWord = "******";

            // Act
            bool ok = vm.Three.Count == 0;

            // Assert
            Assert.IsTrue(ok);
        }
    }
}
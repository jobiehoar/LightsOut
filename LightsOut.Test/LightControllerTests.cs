using NUnit.Framework;

namespace LightsOut.Test
{
    public class LightControllerTests
    {
        private LightController _lightController;
        private int _xMax = 5;
        private int _yMax = 5;

        [SetUp]
        public void Setup()
        {
            _lightController = new LightController();
        }

        [Test]
        public void Given_a_user_presses_light_When_selected_light_is_on_top_left_boundary_Then_calculate_lights_correctly()
        {
            var actualLightsOn = new int[1, 2] { { 0, 0 } };
            var actualLights = LightsStub.LightStub(actualLightsOn, _xMax, _yMax);

            var expectedLightsOn = new int[2, 2] { { 0, 1 }, { 1, 0 } };
            var expectedLights = LightsStub.LightStub(expectedLightsOn, _xMax, _yMax);

            _lightController.Press(actualLights, _xMax, _yMax, 0, 0);

            Assert.AreEqual(expectedLights, actualLights);
        }

        [Test]
        public void Given_a_user_presses_light_When_selected_light_is_on_bottom_right_boundary_Then_calculate_lights_correctly()
        {
            var actualLightsOn = new int[1, 2] { { 4, 4 } };
            var actualLights = LightsStub.LightStub(actualLightsOn, _xMax, _yMax);

            var expectedLightsOn = new int[2, 2] { { 3, 4 }, { 4, 3 } };
            var expectedLights = LightsStub.LightStub(expectedLightsOn, _xMax, _yMax);

            _lightController.Press(actualLights, _xMax, _yMax, 4, 4);

            Assert.AreEqual(expectedLights, actualLights);
        }
    }
}

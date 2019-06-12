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
            var inputStub = LightStub(0, 0);

            var expectedStub = LightStub(0, 1);
            expectedStub[1, 0] = true;

            _lightController.Press(inputStub, _xMax, _yMax, 0, 0);

            Assert.AreEqual(expectedStub, inputStub);
        }

        [Test]
        public void Given_a_user_presses_light_When_selected_light_is_on_bottom_right_boundary_Then_calculate_lights_correctly()
        {
            var inputStub = LightStub(4, 4);

            var expectedStub = LightStub(3, 4);
            expectedStub[4, 3] = true;

            _lightController.Press(inputStub, _xMax, _yMax, 4, 4);

            Assert.AreEqual(expectedStub, inputStub);
        }

        private bool[,] LightStub(int xInput, int yInput)
        {
            var lights= new bool[_xMax, _yMax];

            for (var x = 0; x < _xMax; x++)
            {
                for (var y = 0; y < _yMax; y++)
                {
                    if (xInput.Equals(x) && yInput.Equals(y))
                        lights[x, y] = true;
                    else
                        lights[x, y] = false;
                }
            }

            return lights;
        }
    }
}

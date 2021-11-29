using WebDotPainter.Entity;
using System.Collections.Generic;
using WebDotPainter.Classes;

namespace WebDotPainter.Database
{
    public static class TestData
    {
        public static void Init(AppDbContext context)
        {
            var testDot1 = new Circle
            {
                PositionX = 200,
                PositionY = 200,
                Radius = 55,
                Color = "Yellow",
                Comments = new List<CircleComment>()
            };
            context.Circle.Add(testDot1);

            var testDot3 = new Circle
            {
                PositionX = 400,
                PositionY = 500,
                Radius = 30,
                Color = "Blue",
                Comments = new List<CircleComment>()
            };
            context.Circle.Add(testDot3);

            var testDot2 = new Circle
            {
                PositionX = 800,
                PositionY = 100,
                Radius = 20,
                Color = "Red",
                Comments = new List<CircleComment>()
            };
            context.Circle.Add(testDot2);
            for(var i = 0; i < 3; i++)
            {
                var comment = new CircleComment
                {
                    CircleId = testDot1.Id,
                    Text = $"Hello {i}",
                    TextAreaColor = "Blue"
                };
                context.CircleComments.Add(comment);
            }
            var comment1 = new CircleComment
            {
                CircleId = testDot1.Id,
                Text = "Hello my friend",
                TextAreaColor = "Red"
            };
            context.CircleComments.Add(comment1);

            var comment2 = new CircleComment
            {
                CircleId = testDot1.Id,
                Text = "123123aasdasd12312312312asd",
                TextAreaColor = "Blue"
            };
            context.CircleComments.Add(comment2);
            var comment3 = new CircleComment
            {
                CircleId = testDot1.Id,
                Text = "Hello",
                TextAreaColor = "Yellow"
            };
            context.CircleComments.Add(comment3);
            var comment4 = new CircleComment
            {
                CircleId = testDot2.Id,
                Text = "Hello",
                TextAreaColor = "White"
            };
            context.CircleComments.Add(comment4);

            context.SaveChanges();
        }
    }
}

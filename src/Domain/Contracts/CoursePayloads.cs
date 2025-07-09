using System.Collections.Generic;
using dotnetcore_graphql.src.GraphqlApi.Common;
using dotnetcore_graphql.src.Domain.Model;

namespace dotnetcore_graphql.src.Domain.Contracts
{
    public class CoursePayloadBase : Payload
    {
        protected CoursePayloadBase(Course course)
        {
            Course = course;
        }

        protected  CoursePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Course Course { get; }
    }

    public class CreateCoursePayload : CoursePayloadBase
    {
        public CreateCoursePayload(Course course) : base(course)
        {
        }

        public CreateCoursePayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }

    public class AddModulePayload : CoursePayloadBase
    {
        public AddModulePayload(Course course) : base(course)
        {
        }

        public AddModulePayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }

    public class EnrollStudentPayload : CoursePayloadBase
    {
        public EnrollStudentPayload(Course course) : base(course)
        {
        }

        public EnrollStudentPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}

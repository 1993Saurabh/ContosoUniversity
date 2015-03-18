﻿namespace ContosoUniversity.Features.Department
{
    using System.Linq;
    using System.Threading.Tasks;
    using DAL;
    using Infrastructure.Mapping;
    using MediatR;

    public class EditQueryHandler : IAsyncRequestHandler<EditQuery, EditModel>
    {
        private readonly SchoolContext _db;

        public EditQueryHandler(SchoolContext db)
        {
            _db = db;
        }

        public async Task<EditModel> Handle(EditQuery message)
        {
            var department = await _db.Departments
                .Where(d => d.DepartmentID == message.Id)
                .ProjectToSingleOrDefaultAsync<EditModel>();

            return department;
        }
    }
}
using AutoMapper;
using TransactionsAPI.Entities.Users;
using TransactionsAPI.DTOs.Users.Creation;

namespace TransactionsAPI.Services.Mapper
{
    public class Mapper : AutoMapper.Profile
    {
        public Mapper()
        {
            CreateMap<UserProfile, ProfileDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<Transaction, TransactionQueryDTO>().ReverseMap();
        }
}
}


namespace DevFreelancer.Application.ViewModels.UserSkill
{
    public class UserSkillViewAllModel
    {
        public UserSkillViewAllModel()
        {
                
        }
        public UserSkillViewAllModel(string nameUser, string nameSkill)
        {
            NameUser = nameUser;
            NameSkill = nameSkill;
        }

        public string NameUser { get; private set; }
        public string NameSkill { get; private set; }
    }
}

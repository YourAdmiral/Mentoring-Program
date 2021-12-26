using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, 
            UserTask task)
        {
            try
            {
                if (userId < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var user = _userDao.GetUser(userId);

                if (user == null)
                {
                    throw new NullReferenceException();
                }

                var tasks = user.Tasks;

                foreach (var t in tasks)
                {
                    if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new UserTaskException("Task already exists");
                    }
                }

                tasks.Add(task);

                return 0;
            }
            catch(ArgumentOutOfRangeException)
            {
                return -1;
            }
            catch(NullReferenceException)
            {
                return -2;
            }
            catch(UserTaskException)
            {
                return -3;
            }
            catch(Exception)
            {
                return -4;
            }
        }
    }
}
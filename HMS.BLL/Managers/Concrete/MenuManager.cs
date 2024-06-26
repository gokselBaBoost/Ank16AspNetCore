﻿using HMS.BLL.Managers.Abstract;
using HMS.DAL.Services.Abstract;
using HMS.DAL.Services.Concrete;
using HMS.DTO;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Managers.Concrete
{
    public class MenuManager : Manager<MenuDto, Menu>
    {
        public MenuManager(MenuService service) : base(service)
        {
        }
    }
}

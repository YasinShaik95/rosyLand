﻿using rosyLandApi.Entities;

namespace api.Interfaces;

public interface ITokenService
{
  string CreateToken(User user);
}
/** @jsxImportSource @emotion/react */
import React from 'react';
import { UserIcon } from '../Icons';
import { Link } from 'react-router-dom';
import { headerStyles, logoStyles, searchInputStyles, signInLinkStyles } from '../styles/HeaderStyles';

export const Header = () => {
  const handleSearchInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    console.log(e.currentTarget.value);
  };

  return (
    <div css={headerStyles}>
      <Link to="./" css={logoStyles}>Web Library</Link>
      <input type="text" placeholder="Search..." onChange={handleSearchInputChange} css={searchInputStyles} />
      <Link to="./signin" css={signInLinkStyles}>
        <UserIcon />
        <span>Sign In</span>
      </Link>
    </div>
  );
};

/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import user from './assets/user.svg';

export const UserIcon = () => (
    <img src={user} alt='User' width='12px' 
        css={css`
        width: 12px;
        opacity: 0.6;
    `}/>
);

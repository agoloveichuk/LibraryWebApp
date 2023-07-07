/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import React, { ReactNode } from "react";
import { PageTitle } from "./PageTitle";

interface Props {
    title?: string;
    children: ReactNode;
}

export const Page = ({ title, children }: Props) => (
    <div css={css`
    margin: 50px auto 20px auto;
    padding: 30px 20px;
    max-width: 600px;
    `}>
        {title && <PageTitle>{title}</PageTitle>}
        {children}
    </div>
);
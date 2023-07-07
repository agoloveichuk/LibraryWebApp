/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { gray2, gray3 } from '../styles/Styles';
import { AuthorData } from "./AuthorData";

interface Props {
    data: AuthorData;
}

export const Author = ({ data }: Props) => (
    <div css={css`
        padding: 10px 0px;
    `}>
        <div css={css`
            padding: 10px 0px;
            font-size: 19px;
        `}>
            {data.name}
            {data.dateOfBirth.toLocaleDateString()}
        </div>
    </div>
);
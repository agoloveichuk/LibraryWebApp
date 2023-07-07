/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import React from 'react';
import { AuthorList } from '../components/AuthorList';
import { getAuthors, AuthorData } from '../components/AuthorData';
import { Page } from '../components/Page';
import { PageTitle } from '../components/PageTitle';
import { PrimaryButton } from '../styles/Styles';

export const HomePage = () => {
    const [
        authors,
        setAuthors,
    ] = React.useState<AuthorData[]>([]);
    const [
        authorsLoading,
        setAuthorsLoading
    ] = React.useState(true);
    React.useEffect(() => {
        const doGetAuthors = async () => {
            const authors = await
            getAuthors();
            setAuthors(authors);
            setAuthorsLoading(false);
        };
        doGetAuthors();
    }, []);
    const handleFindAuthorClick = () => {
        console.log('TODO - move to the FindAuthorPage');
    }
    return (
        <Page>
            <div css={css`
                display: flex;
                align-items: center;
                justify-content: space-between;
            `}>
                <PageTitle>Authors and books</PageTitle>
                <PrimaryButton onClick={handleFindAuthorClick}>Find particular author</PrimaryButton>
            </div>
            {authorsLoading? (
                <div>Loading</div>
            ) : (
                <AuthorList data={authors || []} />
            )}
        </Page>
    );
}
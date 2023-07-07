/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Header } from "./components/Header";
import { HomePage } from "./pages/HomePage";
import { fontFamily, fontSize, gray2 } from './styles/Styles';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { SignInPage } from './pages/SignInPage';
import { BooksPage } from './pages/BooksPage';
import { AuthorsPage } from './pages/AuthorsPage';
import { ReviewsPage } from './pages/ReviewsPage';
import { NotFoundPage } from './pages/NotFoundPage';

function App() {
  return (
    <BrowserRouter>
      <div css={css`
        font-family: ${fontFamily};
        font-size: ${fontSize};
        color: ${gray2};
        `}>
          <Header />
          <Routes>
            <Route path='' element={<HomePage />} />
            <Route path='signin' element={<SignInPage />} />
            <Route path='books' element={<BooksPage />} />
            <Route path='authors' element={<AuthorsPage />} />
            <Route path='reviews' element={<ReviewsPage />} />
            <Route path='*' element={<NotFoundPage />} />
          </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
